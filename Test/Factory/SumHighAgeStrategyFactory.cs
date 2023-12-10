using Test.Strategies.AgeStrategy;
using Test.Strategies;
using Test.Strategies.SumMidAgeStrategy;
using Test.Strategies.SumHighAgeStrategy;

namespace Test.Factory
{
    public static class SumHighAgeStrategyFactory
    {
        /// <summary>
        /// This Fcatory is responsible for getting the proper Sum high age strategy strategy
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static ILoanStrategy GetStrategy(int sum)
        {
            if (sum < 15000)
            {
                return new LowSumHighAgeStrategy();
            }
            else if (sum >= 15000 && sum < 30000)
            {
                return new MidSumHighAgeStrategy();
            }
            else if (sum >= 30000)
            {
                return new HighSumHighAgeStrategy();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Not a valid sum");
            }
        }
    }
}
