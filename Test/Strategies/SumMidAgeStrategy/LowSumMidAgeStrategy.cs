using System.Text;

namespace Test.Strategies.SumMidAgeStrategy
{
    public class LowSumMidAgeStrategy : ILoanStrategy
    {
        private static float interestRate = 2f;

        /// <summary>
        /// Calculates the loan cost for a mid age with low sum strategy:
        /// 2% interest rate
        /// In case month period is  > 12, need to add 0.15% interest rate for each extra month
        /// </summary>
        /// <param name="loanSum">(int) Wanted loan sum</param>
        /// <param name="monthPeriod">(int) Month period</param>
        /// <returns></returns>
        public StringBuilder GetTotalLoanDetails(int loanSum, int monthPeriod)
        {
            float extraMonthInterest = 0;
            float loanInterest = loanSum * (interestRate / 100);
            float totalLoanCost = loanSum + loanInterest;

            if (monthPeriod > StrategyHelper.MINPERIOD)
            {
                extraMonthInterest = loanSum * (monthPeriod - StrategyHelper.MINPERIOD) * (StrategyHelper.EXTRAINT / 100);
                totalLoanCost += extraMonthInterest;
            }

            return StrategyHelper.GetLoanDetails(loanSum, monthPeriod, interestRate, loanInterest, totalLoanCost, extraMonthInterest, null);
        }
    }
}
