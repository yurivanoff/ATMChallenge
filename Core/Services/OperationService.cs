using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services
{
    public class OperationService : IOperationService
    {
        private readonly ICashMachineValuesRepository _machineCashValuesRepository;

        public OperationService(ICashMachineValuesRepository machineCashValuesRepository)
        {
            _machineCashValuesRepository = machineCashValuesRepository;
        }

        public Dictionary<int, int> Withdraw(int userAmount)
        {
            try
            {
                var machineAvailableValues = _machineCashValuesRepository.GetValues();

                ValidateOperation(userAmount, machineAvailableValues);

                var operationValuesResponse = new Dictionary<int, int>();

                foreach (int machineValue in machineAvailableValues)
                {
                    int count = 0;

                    while (userAmount >= machineValue)
                    {
                        count++;
                        userAmount -= machineValue;
                    };

                    if (count > 0)
                        operationValuesResponse.Add(machineValue, count);
                }

                return operationValuesResponse;
            } 
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ValidateOperation(int amount, List<int> machineValues)
        {
            try
            {
                var minimumAcceptedValue = machineValues.OrderBy(x => x).First();

                if (amount < minimumAcceptedValue)
                    throw new Exception("Valor inferior as notas disponíveis neste caixa");

                foreach (int value in machineValues)
                {
                    while (amount >= value)
                    {
                        amount -= value;
                    };
                }

                if (amount > 0)
                    throw new Exception("Valor não aceito");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
