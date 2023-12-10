using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using Test.Factory;
using Test.Model;
using Test.Repository;
using Test.Repository.ClientJsonRepository;
using Test.Strategies;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : Controller
    {
        private readonly LoanPlanner _loanPlanner;
        private readonly IClientRepository _clientRepository;

        public LoanController(LoanPlanner loanPlanner, IClientRepository clientRepository)
        {
            _loanPlanner = loanPlanner;
            _clientRepository = clientRepository;
        }

        [HttpGet]
        [Route("GetLoanDetalis")]
        public async Task<IActionResult> GetLoanDetalis(int clientId, int loanSum, int monthPeriod)
        {
            StringBuilder totalLoanDetails;

            try
            {
                Client client = _clientRepository.GetClientById(clientId);

                if (client == null)
                {
                    return NotFound($"Client with Id {clientId} is not found");
                }

                ILoanStrategy strategy = AgeStrategyFactory.GetStrategy(client.Age);

                _loanPlanner.SetLoanStrategy(strategy);

                totalLoanDetails = _loanPlanner.PlanLoan(loanSum, monthPeriod);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(totalLoanDetails.ToString());
        }
    }
}
