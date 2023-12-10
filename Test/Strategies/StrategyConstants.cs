using System.Text;

namespace Test.Strategies
{
    public static class StrategyHelper
    {
        public const float PRIME = 1.5f;
        public const int MINPERIOD = 12;
        public const float EXTRAINT = 0.15f;

        /// <summary>
        /// Build the result answer based on the loan details
        /// </summary>
        /// <param name="loanSum"></param>
        /// <param name="monthPeriod"></param>
        /// <param name="interestRate"></param>
        /// <param name="loanInterest"></param>
        /// <param name="totalLoanCost"></param>
        /// <param name="extraMonthInterest"></param>
        /// <param name="primeInterest"></param>
        /// <returns></returns>
        public static StringBuilder GetLoanDetails(int loanSum, int monthPeriod, float interestRate, float loanInterest, float totalLoanCost, float extraMonthInterest, float? primeInterest)
        {
            StringBuilder loanDetails = new StringBuilder();

            loanDetails.Append($"Wanted Loan: {loanSum}\n");
            loanDetails.Append($"{interestRate}% interest rate  = {loanInterest}\n");
            loanDetails.Append(primeInterest is null ? "No prime intrest\n" : $"{PRIME}% prime rate  = {primeInterest}\n");
            loanDetails.Append(monthPeriod < 12 ? "No Extra month intrest\n" : $"{monthPeriod - 12} * {EXTRAINT} extra month rate = {extraMonthInterest}\n");
            loanDetails.Append($"Total loan cost: {totalLoanCost}\n");
            return loanDetails;
        }
    }
}
