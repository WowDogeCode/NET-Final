using Core.Utilities.Results;

namespace Core.Business
{
    public static class BusinessRules
    {
        public static IResult? Check(params IResult[] rules)
        {
            foreach (var rule in rules)
            {
                if (!rule.IsSuccess)
                {
                    return rule;
                }
            }

            return null;
        }
    }
}
