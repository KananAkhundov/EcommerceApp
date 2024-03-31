using Core.Results.Abstract;

namespace Core.Business
{
    public class BusinessRules
    {
        public static IResult Execute(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
