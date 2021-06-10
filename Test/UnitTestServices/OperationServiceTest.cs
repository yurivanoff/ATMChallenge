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
        public void WithdrawFirstTestOneHundredAndFiftySuccess()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);
            var withdrawResult = operationService.Withdraw(150);

            Assert.True(withdrawResult.First(x => x.Key == 100).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 50).Value == 1);
        }

        [Fact(DisplayName = "TESTE 1 - NOTAS DISPONIVEIS: [100, 50, 20] - Saque 120")]
        public void WithdrawFirstTestOneHundredAndTwentySuccess()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);
            var withdrawResult = operationService.Withdraw(120);

            Assert.True(withdrawResult.First(x => x.Key == 100).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 20).Value == 1);
        }

        [Fact(DisplayName = "TESTE 1 - NOTAS DISPONIVEIS: [100, 50, 20] - Saque 170")]
        public void WithdrawFirstTestOneHundredAndSeventySuccess()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);
            var withdrawResult = operationService.Withdraw(170);

            Assert.True(withdrawResult.First(x => x.Key == 100).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 50).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 20).Value == 1);
        }

        [Fact(DisplayName = "TESTE 1 - NOTAS DISPONIVEIS: [100, 50, 20] - Saque 1")]
        public void WithdrawFirstTestOneError()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);

            Assert.ThrowsAny<Exception>(() => operationService.Withdraw(1));
        }

        [Fact(DisplayName = "TESTE 1 - NOTAS DISPONIVEIS: [100, 50, 20] - Saque 5")]
        public void WithdrawFirstTestFiveError()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);

            Assert.ThrowsAny<Exception>(() => operationService.Withdraw(5));
        }

        [Fact(DisplayName = "TESTE 1 - NOTAS DISPONIVEIS: [100, 50, 20] - Saque 130")]
        public void WithdrawFirstTestOneHundredAndThirtyError()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);

            Assert.ThrowsAny<Exception>(() => operationService.Withdraw(130));
        }

        [Fact(DisplayName = "TESTE 2 - NOTAS DISPONIVEIS: [100, 50, 20, 10, 5] - Saque 175")]
        public void WithdrawSecondTestOneHundredAndSeventyFiveSuccess()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20, 10, 5 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);
            var withdrawResult = operationService.Withdraw(175);

            Assert.True(withdrawResult.First(x => x.Key == 100).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 50).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 20).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 5).Value == 1);
        }

        [Fact(DisplayName = "TESTE 2 - NOTAS DISPONIVEIS: [100, 50, 20, 10, 5] - Saque 110")]
        public void WithdrawSecondTestOneHundredAndTenSuccess()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20, 10, 5 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);
            var withdrawResult = operationService.Withdraw(110);

            Assert.True(withdrawResult.First(x => x.Key == 100).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 10).Value == 1);
        }

        [Fact(DisplayName = "TESTE 2 - NOTAS DISPONIVEIS: [100, 50, 20, 10, 5] - Saque 75")]
        public void WithdrawSeventyFiveSuccess()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20, 10, 5 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);
            var withdrawResult = operationService.Withdraw(75);

            Assert.True(withdrawResult.First(x => x.Key == 50).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 20).Value == 1);
            Assert.True(withdrawResult.First(x => x.Key == 5).Value == 1);
        }

        [Fact(DisplayName = "TESTE 2 - NOTAS DISPONIVEIS: [100, 50, 20, 10, 5] - Saque 42")]
        public void WithdrawFortyTwoError()
        {
            _machineCashRepositoryMock.Setup(x => x.GetValues()).Returns(() => new List<int> { 100, 50, 20, 10, 5 });

            var operationService = new OperationService(_machineCashRepositoryMock.Object);

            Assert.ThrowsAny<Exception>(() => operationService.Withdraw(42));
        }
    }
}
