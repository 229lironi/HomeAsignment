using System.Text;
using Test.Factory;

namespace Test.Strategies.SumHighAgeStrategy
{
    public class LowSumHighAgeStrategy : ILoanStrategy
    {
        private static float interestRate = 1.5f;

        /// <summary>
        /// Calculates the total loan cost for a High sum mid age strategy:
        /// 1.5% interest rate + prime rate
        /// In case month period is  > 12, need to add 0.15% interest rate for each extra month
        /// </summary>
        /// <param name="loanSum">(int) Wanted loan sum</param>
        /// <param name="monthPeriod">(int) Month period</param>
        /// <returns></returns>
        public StringBuilder GetTotalLoanDetails(int loanSum, int monthPeriod)
        {
            float extraMonthInterest = 0;
            float loanInterest = loanSum * (interestRate / 100);
            float primeInterest = loanSum * (StrategyHelper.PRIME / 100);
            float totalLoanCost = loanSum + loanInterest + primeInterest;

            if (monthPeriod > StrategyHelper.MINPERIOD)
            {
                extraMonthInterest = loanSum * (monthPeriod - StrategyHelper.MINPERIOD) * (StrategyHelper.EXTRAINT / 100);
                totalLoanCost += extraMonthInterest;
            }

            return StrategyHelper.GetLoanDetails(loanSum, monthPeriod, interestRate, loanInterest, totalLoanCost, extraMonthInterest, primeInterest);
        }
    }
}
