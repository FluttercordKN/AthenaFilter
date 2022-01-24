using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AthenaFilter
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConditionType
    {
        And,
        Or,
        Not,
        StartsWith,
        EndsWith,
        Contains,
        Equals,
        Regex
    }

    [JsonConverter(typeof(ConditionConverter))]
    public abstract class Condition
    {
        public abstract ConditionType Type { get; }
        public abstract bool Execute(string arg);
    }

    public class ConditionNot : Condition
    {
        public Condition Condition { get; set; }
        public override ConditionType Type => ConditionType.Not;

        public override bool Execute(string arg)
        {
            return !Condition.Execute(arg);
        }
    }

    public abstract class ConditionSet : Condition
    {
        public IReadOnlyCollection<Condition> Conditions { get; set; }
    }

    public class ConditionAnd : ConditionSet
    {
        public override ConditionType Type => ConditionType.And;

        public override bool Execute(string arg)
        {
            return Conditions.All(e => e.Execute(arg));
        }
    }

    public class ConditionOr : ConditionSet
    {
        public override ConditionType Type => ConditionType.And;

        public override bool Execute(string arg)
        {
            return Conditions.Any(e => e.Execute(arg));
        }
    }

    public abstract class ConditionValue : Condition
    {
        public string Value { get; set; }
    }

    public class ConditionRegex : ConditionValue
    {
        public override ConditionType Type => ConditionType.Regex;

        public override bool Execute(string arg)
        {
            return Regex.IsMatch(arg, Value);
        }
    }

    public abstract class ConditionCase : ConditionValue
    { 
        public bool MatchCase { get; set; }
        protected StringComparison Comparison => MatchCase ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
    }

    public class ConditionStartsWith : ConditionCase
    {
        public override ConditionType Type => ConditionType.StartsWith;

        public override bool Execute(string arg)
        {
            return arg.StartsWith(Value, Comparison);
        }
    }

    public class ConditionEndsWith : ConditionCase
    {
        public override ConditionType Type => ConditionType.EndsWith;

        public override bool Execute(string arg)
        {
            return arg.EndsWith(Value, Comparison);
        }
    }

    public class ConditionConstains : ConditionCase
    {
        public override ConditionType Type => ConditionType.Contains;

        public override bool Execute(string arg)
        {
            return arg.Contains(Value, Comparison);
        }
    }

    public class ConditionEquals : ConditionCase
    {
        public override ConditionType Type => ConditionType.Equals;

        public override bool Execute(string arg)
        {
            return arg.Equals(Value, Comparison);
        }
    }
}
