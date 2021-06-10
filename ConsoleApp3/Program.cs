using Core.Enum;
using Core.Interfaces;
using Core.Repository;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICashMachineValuesRepository, CashMachineValuesRepository>()
                .AddSingleton<IOperationService, OperationService>()
                .AddSingleton<ICashMachineService, CashMachineService>()
                .BuildServiceProvider();

            var cashMachineService = serviceProvider.GetService<ICashMachineService>();
            cashMachineService.Start(CashMachineValuesOptions.HundredFiftyTwentyTenFive);
        }
    }
}
