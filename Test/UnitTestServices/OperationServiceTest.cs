using Core.Interfaces;
using Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Test.UnitTestServices
{
    public class OperationServiceTest
    {
        private readonly Mock<ICashMachineValuesRepository> _machineCashRepositoryMock;

        public OperationServiceTest()
        {
            _machineCashRepositoryMock = new Mock<ICashMachineValuesRepository>();
        }

        [Fact(DisplayName = "TESTE 1 - NOTAS DISPONIVEIS: [100, 50, 20] - Saque 150")]
        public void WithdrawOneHundredAndFiftySuccess()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);
            var withdrawResult = operationService.Withdraw(150);

            Assert.True(withdrawResult.First(x => x.Key == 100).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 50).Value == 1);
        }

        [Fact(DisplayName = "TESTE 1 - NOTAS DISPONIVEIS: [100, 50, 20] - Saque 120")]
        public void WithdrawOneHundredAndTwentySuccess()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);
            var withdrawResult = operationService.Withdraw(120);

            Assert.True(withdrawResult.First(x => x.Key == 100).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 20).Value == 1);
        }

        [Fact(DisplayName = "TESTE 1 - NOTAS DISPONIVEIS: [100, 50, 20] - Saque 170")]
        public void WithdrawOneHundredAndSeventySuccess()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);
            var withdrawResult = operationService.Withdraw(170);

            Assert.True(withdrawResult.First(x => x.Key == 100).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 50).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 20).Value == 1);
        }

        [Fact(DisplayName = "TESTE 1 - NOTAS DISPONIVEIS: [100, 50, 20] - Saque 1")]
        public void WithdrawOneError()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);

            Assert.ThrowsAny<Exception>(() => operationService.Withdraw(1));
        }

        [Fact(DisplayName = "TESTE 1 - NOTAS DISPONIVEIS: [100, 50, 20] - Saque 5")]
        public void WithdrawFiveError()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);

            Assert.ThrowsAny<Exception>(() => operationService.Withdraw(5));
        }

        [Fact(DisplayName = "TESTE 1 - NOTAS DISPONIVEIS: [100, 50, 20] - Saque 130")]
        public void WithdrawOneHundredAndThirtyError()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);

            Assert.ThrowsAny<Exception>(() => operationService.Withdraw(130));
        }
    }
}
