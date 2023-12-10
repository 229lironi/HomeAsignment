using System.Text;

namespace Test.Strategies
{
    public interface ILoanStrategy
    {
        public StringBuilder GetTotalLoanDetails(int loanSum, int monthPeriod); 
    }
}
