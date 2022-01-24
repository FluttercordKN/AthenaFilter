using Newtonsoft.Json;

using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AthenaFilter
{
    public partial class Main : Form
    {
        private bool _isRunning = false;
        private bool _stopRequest = false;

        public Main()
        {
            InitializeComponent();
        }

        private void BtnInputBrowse_Click(object sender, EventArgs e)
        {
            if (ofdInput.ShowDialog() == DialogResult.OK)
                tbInput.Text = string.Join(Environment.NewLine, ofdInput.FileNames);
        }

        private void BtnFilterBrowse_Click(object sender, EventArgs e)
        {
            if (ofdFilter.ShowDialog() == DialogResult.OK)
                tbFilter.Text = ofdFilter.FileName;
        }

        private void BtnResultBrowse_Click(object sender, EventArgs e)
        {
            if (sfdResult.ShowDialog() == DialogResult.OK)
                tbResult.Text = sfdResult.FileName;
        }

        private async void BtnGo_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                Log("Canceled");
                _stopRequest = true;
                return;
            }

            try
            {
                tbLog.Clear();
                SetEnabledControls(false);
                btnGo.Text = "Cancel";
                _isRunning = true;
                pbMain.Value = 0;
                pbMain.Maximum = 1;

                Log("Validation…");

                var conditionsFile = tbFilter.Text;
                if (string.IsNullOrWhiteSpace(conditionsFile))
                {
                    Log("Filters are not spesified");
                    return;
                }
                if (!File.Exists(conditionsFile))
                {
                    Log("Filters file is not specified");
                    return;
                }
                var conditionsFileContent = await File.ReadAllTextAsync(conditionsFile);
                if (string.IsNullOrWhiteSpace(conditionsFileContent))
                {
                    Log("Filters file is empty");
                    return;
                }
                var conditions = JsonConvert.DeserializeObject<Condition[]>(conditionsFileContent);

                var resultFile = tbResult.Text;
                if (string.IsNullOrWhiteSpace(resultFile))
                {
                    Log("Result file is not specified");
                    return;
                }

                var inputFiles = tbInput.Lines.Where(e => !string.IsNullOrWhiteSpace(e)).ToArray();
                if (inputFiles.Length == 0)
                {
                    Log($"Input files are not spesified");
                    return;
                }
                foreach (var inputFile in inputFiles)
                    if (!File.Exists(inputFile))
                    {
                        Log($"File {inputFile} does not exists");
                        return;
                    }

                Log("Analisys…");

                var totalLines = 0;
                foreach (var inputFile in inputFiles)
                {
                    var inputFileLines = 0;
                    using var reader = new StreamReader(inputFile);
                    var firstLine = await reader.ReadLineAsync();
                    if (string.IsNullOrWhiteSpace(firstLine))
                    {
                        Log($"File {inputFile} is empty");
                        return;
                    }
                    var headers = firstLine.Split(',');
                    if (conditions.Length != headers.Length)
                    {
                        Log($"Conditions count is {conditions.Length}, but {inputFile} has {headers.Length} columns");
                        return;
                    }
                    while (await reader.ReadLineAsync() != null)
                    {
                        inputFileLines++;
                        if (_stopRequest)
                            return;
                    }
                    Log($"{inputFile} - {inputFileLines} lines");
                    totalLines += inputFileLines;
                }
                pbMain.Maximum = totalLines;
                    
                Log("Execution…");

                using var resultWriter = new StreamWriter(resultFile);
                foreach (var inputFile in inputFiles)
                {
                    Log($"Processing {inputFile}");
                    using var reader = new StreamReader(inputFile);
                    var firstLine = await reader.ReadLineAsync();
                    await resultWriter.WriteLineAsync(firstLine);
                    string line;
                    while (!string.IsNullOrEmpty(line = await reader.ReadLineAsync()))
                    {
                        var pass = true;
                        var values = line.Split(',');
                        for (var i = 0; i < conditions.Length; i++)
                            if (conditions[i]?.Execute(values[i][1..^1]) == false)
                            {
                                pass = false;
                                break;
                            }
                        if (pass)
                            await resultWriter.WriteLineAsync(line);
                        pbMain.Value++;
                        if (_stopRequest)
                            return;
                    }
                }

                Log("Completed");
            }
            catch (Exception ex)
            {
                Log($"Error: {ex}");
            }
            finally
            {
                SetEnabledControls(true);
                btnGo.Text = "Go";
                _isRunning = false;
                _stopRequest = false;
            }
        }

        private void SetEnabledControls(bool enabled)
        {
            btnInputBrowse.Enabled = enabled;
            btnFilterBrowse.Enabled = enabled;
            btnResultBrowse.Enabled = enabled;
            tbInput.Enabled = enabled;
            tbFilter.Enabled = enabled;
            tbResult.Enabled = enabled;
        }

        private void Log(string message)
        {
            tbLog.AppendText($"{DateTime.Now.ToLongTimeString()}: {message}{Environment.NewLine}");
        }

        private void tbInput_DragDrop(object sender, DragEventArgs e)
        {
            var filesData = e.Data.GetData(DataFormats.FileDrop);
            if (filesData != null)
            {
                var files = (string[])filesData;
                foreach (var file in files)
                    tbInput.AppendText($"{file}{Environment.NewLine}");
            }
        }

        private void tb_files_DragOver(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
                e.Effect = DragDropEffects.Link;
        }

        private void tbFilter_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var files = (string[])data;
                tbFilter.Text = files[0];
            }
        }
    }
}
