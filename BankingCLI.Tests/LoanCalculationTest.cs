using System;
using BankingCLI.Common.Config;
using BankingCLI.Common.Interfaces;
using BankingCLI.Common.Models;
using BankingCLI.Services.LoanCalculation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BankingCLI.Tests
{
    public class LoanCalculationTest
    {
        private LoanCalculationService loanCalculationService;

        [SetUp]
        public void Setup()
        {
            var options = Options.Create(new LoanConfig
            {
                AdministrationFeePercent = 1,
                AdministrationFeeValue = 10000,
                AnnualInterestRate = 5,
            });

            loanCalculationService = new LoanCalculationService(options);
        }

        [TestCase(500000, 10, 5000)]
        public void CalculateAdministrationFee(double amount, int duration, double administrationFee)
        {
            var serviceModel = new LoanCalculationServiceModel
            {
                Amount = amount,
                Duration = duration
            };

            var result = loanCalculationService.CalculateLoan(serviceModel);
            Assert.AreEqual(Math.Round(administrationFee), Math.Round(result.AdministrationFee));
        }

        [TestCase(500000, 10, 6904.28)]
        public void CalculateMonthlyPayment(double amount, int duration, double monthlyPayment)
        {
            var serviceModel = new LoanCalculationServiceModel
            {
                Amount = amount,
                Duration = duration
            };

            var result = loanCalculationService.CalculateLoan(serviceModel);
            Assert.AreEqual(Math.Round(monthlyPayment), Math.Round(result.MonthlyPayment));
        }

        [TestCase(500000, 10, 323505)]
        public void CalculateInterestRate(double amount, int duration, double interestsRate)
        {
            var serviceModel = new LoanCalculationServiceModel
            {
                Amount = amount,
                Duration = duration
            };

            var result = loanCalculationService.CalculateLoan(serviceModel);
            Assert.AreEqual(Math.Round(interestsRate), Math.Round(result.InterestRate));
        }
    }
}
