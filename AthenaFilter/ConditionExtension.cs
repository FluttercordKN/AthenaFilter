namespace AthenaFilter
{
    public static class ConditionExtension
    {
        public static Condition Not(this Condition instance)
        {
            return new ConditionNot { Condition = instance };
        }
    }
}
