using Test.Strategies;
using Test.Strategies.AgeStrategy;

namespace Test.Factory
{
    public static class AgeStrategyFactory
    {
        /// <summary>
        /// This Fcatory is responsible for getting the proper Age strategy
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static ILoanStrategy GetStrategy(int age)
        {
            if (age < 20)
            {
                return new LowAgeStrategy();
            }
            else if (age >= 20 && age < 35)
            {
                return new MidAgeStrategy(new LoanPlanner());
            }
            else if (age >= 35)
            {
                return new HighAgeStrategy(new LoanPlanner());
            }
            else
            {
                throw new ArgumentOutOfRangeException("Not a valid age");
            }
        }
    }
}
