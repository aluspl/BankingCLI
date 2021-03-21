using System;
using BankingCLI.Models;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BankingCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureDI();

            var options = Parser.Default.ParseArguments<Parameters>(args);
        }

        private static ServiceProvider ConfigureDI()
        {
            var serviceProvider = new ServiceCollection()
                .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
