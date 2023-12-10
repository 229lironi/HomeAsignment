using Test.Strategies.AgeStrategy;
using Test.Strategies;
using Test.Strategies.SumMidAgeStrategy;

namespace Test.Factory
{
    public static class SumMidAgeStrategyFactory
    {
        /// <summary>
        /// This Fcatory is responsible for getting the proper Sum mid age strategy strategy
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static ILoanStrategy GetStrategy(int sum)
        {
            if (sum < 5000)
            {
                return new LowSumMidAgeStrategy();
            }
            else if (sum >= 5000 && sum < 30000)
            {
                return new MidSumMidAgeStrategy();
            }
            else if (sum >= 3000)
            {
                return new HighSumMidAgeStrategy();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Not a valid sum");
            }
        }
    }
}
