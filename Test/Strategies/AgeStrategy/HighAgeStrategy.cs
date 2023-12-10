using System.Text;
using Test.Factory;

namespace Test.Strategies.AgeStrategy
{
    public class HighAgeStrategy : ILoanStrategy
    {
        private readonly LoanPlanner loanPlanner;

        public HighAgeStrategy(LoanPlanner loanPlanner)
        {
            this.loanPlanner = loanPlanner;
        }

        public StringBuilder GetTotalLoanDetails(int loanSum, int monthPeriod)
        {
            StringBuilder totalLoanDetails;

            ILoanStrategy strategy = SumHighAgeStrategyFactory.GetStrategy(loanSum);

            loanPlanner.SetLoanStrategy(strategy);

            totalLoanDetails = loanPlanner.PlanLoan(loanSum, monthPeriod);

            return totalLoanDetails;
        }
    }
}
