using System.Text;
using Test.Factory;

namespace Test.Strategies.AgeStrategy
{
    public class MidAgeStrategy : ILoanStrategy
    {
        private readonly LoanPlanner loanPlanner;

        public MidAgeStrategy(LoanPlanner loanPlanner)
        {
            this.loanPlanner = loanPlanner;
        }

        public StringBuilder GetTotalLoanDetails(int loanSum, int monthPeriod)
        {
            StringBuilder totalLoanDetails;

            ILoanStrategy strategy = SumMidAgeStrategyFactory.GetStrategy(loanSum);

            loanPlanner.SetLoanStrategy(strategy);

            totalLoanDetails = loanPlanner.PlanLoan(loanSum, monthPeriod);

            return totalLoanDetails;
        }
    }
}
