using System;
using BankingCLI.Common.Config;
using BankingCLI.Common.Interfaces;
using BankingCLI.Common.Models;
using BankingCLI.Services.LoanCalculation;

namespace BankingCLI
{
    public class App
    {
        private readonly ILoanCalculationService LoanCalculationService;
        private readonly ILoanReportService LoanReportService;

        public App(
            ILoanCalculationService loanCalculationService,
            ILoanReportService loanReportService)
        {
            LoanCalculationService = loanCalculationService;
            LoanReportService = loanReportService;
        }

        public void Run(Parameters options)
        {
            var writeServiceModel = new LoanCalculationServiceModel()
            {
                Amount = options.Amount,
                Duration = options.Duration,
            };

            var result = LoanCalculationService.CalculateLoan(writeServiceModel);
            var report = LoanReportService.GenerateReport(result);
            Console.WriteLine(report);

            Console.ReadLine();
        }
    }
}
