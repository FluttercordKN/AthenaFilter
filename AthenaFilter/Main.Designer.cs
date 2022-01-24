
namespace AthenaFilter
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btnInputBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdInput = new System.Windows.Forms.OpenFileDialog();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.btnFilterBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ofdFilter = new System.Windows.Forms.OpenFileDialog();
            this.btnResultBrowse = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sfdResult = new System.Windows.Forms.SaveFileDialog();
            this.btnGo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.AllowDrop = true;
            this.tbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInput.Location = new System.Drawing.Point(70, 12);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(567, 123);
            this.tbInput.TabIndex = 0;
            this.tbInput.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbInput_DragDrop);
            this.tbInput.DragOver += new System.Windows.Forms.DragEventHandler(this.tb_files_DragOver);
            // 
            // btnInputBrowse
            // 
            this.btnInputBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInputBrowse.Location = new System.Drawing.Point(643, 12);
            this.btnInputBrowse.Name = "btnInputBrowse";
            this.btnInputBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnInputBrowse.TabIndex = 1;
            this.btnInputBrowse.Text = "Browse…";
            this.btnInputBrowse.UseVisualStyleBackColor = true;
            this.btnInputBrowse.Click += new System.EventHandler(this.BtnInputBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Files";
            // 
            // ofdInput
            // 
            this.ofdInput.FileName = "openFileDialog1";
            this.ofdInput.Filter = "CSV files|*.csv";
            this.ofdInput.Multiselect = true;
            // 
            // tbFilter
            // 
            this.tbFilter.AllowDrop = true;
            this.tbFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilter.Location = new System.Drawing.Point(70, 141);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(567, 23);
            this.tbFilter.TabIndex = 2;
            this.tbFilter.Text = "config.json";
            this.tbFilter.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbFilter_DragDrop);
            this.tbFilter.DragOver += new System.Windows.Forms.DragEventHandler(this.tb_files_DragOver);
            // 
            // btnFilterBrowse
            // 
            this.btnFilterBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilterBrowse.Location = new System.Drawing.Point(643, 141);
            this.btnFilterBrowse.Name = "btnFilterBrowse";
            this.btnFilterBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnFilterBrowse.TabIndex = 3;
            this.btnFilterBrowse.Text = "Browse…";
            this.btnFilterBrowse.UseVisualStyleBackColor = true;
            this.btnFilterBrowse.Click += new System.EventHandler(this.BtnFilterBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter";
            // 
            // ofdFilter
            // 
            this.ofdFilter.FileName = "openFileDialog1";
            this.ofdFilter.Filter = "JSON file|*.json";
            // 
            // btnResultBrowse
            // 
            this.btnResultBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResultBrowse.Location = new System.Drawing.Point(643, 170);
            this.btnResultBrowse.Name = "btnResultBrowse";
            this.btnResultBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnResultBrowse.TabIndex = 5;
            this.btnResultBrowse.Text = "Browse…";
            this.btnResultBrowse.UseVisualStyleBackColor = true;
            this.btnResultBrowse.Click += new System.EventHandler(this.BtnResultBrowse_Click);
            // 
            // tbResult
            // 
            this.tbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResult.Location = new System.Drawing.Point(70, 171);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(567, 23);
            this.tbResult.TabIndex = 4;
            this.tbResult.Text = "result.csv";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Result";
            // 
            // sfdResult
            // 
            this.sfdResult.Filter = "CSV file|*.csv";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(643, 394);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Log";
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.Location = new System.Drawing.Point(70, 200);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(567, 188);
            this.tbLog.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 398);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Progress";
            // 
            // pbMain
            // 
            this.pbMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbMain.Location = new System.Drawing.Point(70, 394);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(567, 23);
            this.pbMain.TabIndex = 12;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 429);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.btnResultBrowse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFilterBrowse);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInputBrowse);
            this.Controls.Add(this.tbInput);
            this.Name = "Main";
            this.Text = "Athena filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnInputBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdInput;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.Button btnFilterBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog ofdFilter;
        private System.Windows.Forms.Button btnResultBrowse;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog sfdResult;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar pbMain;
    }
}

