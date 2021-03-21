using System;
using System.Collections.Generic;
using System.IO;
using BankingCLI.Common.Config;
using BankingCLI.Common.Interfaces;
using BankingCLI.Services.LoanCalculation;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankingCLI
{
    static class Program
    {
        static void Main(string[] args)
        {
            var provider = new ServiceCollection()
                .SetupConfiguration()
                .SetupServices()
                .BuildServiceProvider();
            try
            {
                Parser
                    .Default
                    .ParseArguments<Parameters>(args)
                    .WithParsed(options => RunApp(provider, options))
                    .WithNotParsed(HandleError);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void RunApp(ServiceProvider provider, Parameters parameters)
        {
            provider.GetService<App>().Run(parameters);
        }

        private static ServiceCollection SetupConfiguration(this ServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();
            serviceCollection.Configure<LoanConfig>(options => configuration.GetSection("Loan").Bind(options));

            return serviceCollection;
        }

        private static ServiceCollection SetupServices(this ServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<ILoanCalculationService, LoanCalculationService>()
                .AddScoped<ILoanReportService, LoanReportService>()
                .AddTransient<App>()
                .AddLogging();
            
            return serviceCollection;
        }

        private static void HandleError(IEnumerable<Error> errors)
        {
            Console.WriteLine("Parameters Errors:");
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }

            Console.ReadLine();
        }
    }
}
