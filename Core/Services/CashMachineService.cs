using Core.Enum;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class CashMachineService : ICashMachineService
    {
        private readonly IOperationService _operationService;
        private readonly ICashMachineValuesRepository _repository;

        public CashMachineService(IOperationService operationService, ICashMachineValuesRepository repository)
        {
            _operationService = operationService;
            _repository = repository;
        }

        public void Start(CashMachineValuesOptions option)
        {
            try
            {
                InitializeCashMachineValues(option);

                while (true)
                {
                    Console.WriteLine("Digite o valor que deseja sacar:");

                    int amount = int.Parse(Console.ReadLine());

                    var operationResponse = _operationService.Withdraw(amount);

                    DisplayOperationUserResponse(operationResponse);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(string.Join("", "Erro: {0}"), ex.Message);
                Console.WriteLine("\n\n");
                Start(option);
            }
        }

        private void InitializeCashMachineValues(CashMachineValuesOptions option)
        {
            try
            {
                switch (option)
                {
                    case CashMachineValuesOptions.HundredFiftyTwenty:
                        _repository.AddValues(new int[] { 100, 50, 20 });
                        break;

                    case CashMachineValuesOptions.HundredFiftyTwentyTenFive:
                        _repository.AddValues(new int[] { 100, 50, 20, 10, 5 });
                        break;

                    case CashMachineValuesOptions.HundredFiftyTwentyTenFiveTwo:
                        _repository.AddValues(new int[] { 100, 50, 20, 10, 5, 2 });
                        break;
                    default:
                        throw new Exception("Opção Inválida");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void DisplayOperationUserResponse(Dictionary<int, int> operationValues)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var value in operationValues)
            {
                sb.AppendLine($"{value.Value} cédula de {value.Key}");
            };

            Console.WriteLine(sb.ToString());
        }
    }
}
