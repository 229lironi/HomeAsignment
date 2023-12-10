using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Test.Controllers;
using Test.Repository;
using Test.Strategies;

namespace TestProject
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(6, 100, 12)]
        public async Task GetClient_ReturnsNotFound_ForNonExistentId(int clientId, int loanSum, int monthPeriod)
        {
            // Arrange
            var fakeRepo = A.Fake<IClientRepository>();
            A.CallTo(() => fakeRepo.GetClientById(A<int>.Ignored))
                .Returns(null);

            var controller = new LoanController(new LoanPlanner(), fakeRepo);

            // Act
            var result = await controller.GetLoanDetalis(clientId, loanSum, monthPeriod);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Theory]
        [InlineData(1, 100, 12)]
        public async Task GetClient_ReturnsOk_ForExistentId(int clientId, int loanSum, int monthPeriod)
        {
            // Arrange
            var fakeRepo = A.Fake<IClientRepository>();
            A.CallTo(() => fakeRepo.GetClientById(A<int>.Ignored))
                .Returns(new Test.Model.Client(clientId, "Liron", "Leibovich", 38));

            var controller = new LoanController(new LoanPlanner(), fakeRepo);
            
            // Act
            var result = await controller.GetLoanDetalis(clientId, loanSum, monthPeriod);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(1, 4500, 13)]
        public async Task ResultReturnOk_ForMidAge_MinSum(int clientId, int loanSum, int monthPeriod)
        {
            // Arrange
            var fakeRepo = A.Fake<IClientRepository>();
            A.CallTo(() => fakeRepo.GetClientById(A<int>.Ignored))
                .Returns(new Test.Model.Client(clientId, "Liron", "Leibovich", 23));

            var controller = new LoanController(new LoanPlanner(), fakeRepo);
            
            // Act
            var result = await controller.GetLoanDetalis(clientId, loanSum, monthPeriod);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualString = Assert.IsType<string>(okResult.Value);
            Assert.Contains("Total loan cost: 4596.75", actualString);
        }
    }
}