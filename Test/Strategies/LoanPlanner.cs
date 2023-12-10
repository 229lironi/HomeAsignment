using System.Text;

namespace Test.Strategies
{
    public class LoanPlanner
    {
        private ILoanStrategy? loanStrategy;

        public void SetLoanStrategy(ILoanStrategy loanStrategy)
        {
            this.loanStrategy = loanStrategy;
        }

        public StringBuilder PlanLoan(int loanSum, int monthPeriod)
        {
            StringBuilder? totalLoanDetails = null;

            try
            {
                if (loanStrategy != null)
                {
                    totalLoanDetails = loanStrategy.GetTotalLoanDetails(loanSum, monthPeriod);
                }
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }

            return totalLoanDetails;
        }
    }
}
