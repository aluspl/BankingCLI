using System;
using BankingCLI.Common.Config;
using BankingCLI.Common.Interfaces;
using BankingCLI.Common.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BankingCLI.Services.LoanCalculation
{
    public class LoanCalculationService : ILoanCalculationService
    {
        private readonly LoanConfig LoanConfig;

        public LoanCalculationService(
            IOptions<LoanConfig> loanConfig)
        {
            LoanConfig = loanConfig.Value;
        }

        public LoanResultServiceModel CalculateLoan(LoanCalculationServiceModel serviceModel)
        {
            var result = new LoanResultServiceModel
            {
                DurationOfLoan = serviceModel.Duration,
                LoanAmount = serviceModel.Amount,
                InterestRate = CalculateInterestRate(serviceModel.Amount, serviceModel.Duration),
                AdministrationFee = CalculateAdministrationFee(serviceModel.Amount),
            };
            result.TotalLoanAmount = result.InterestRate + result.LoanAmount + result.AdministrationFee;
            result.MonthlyPayment = CalculateMonthlyPayment(result.TotalLoanAmount, result.DurationOfLoan);

            return result;
        }

        private double CalculateMonthlyPayment(double totalLoan, int durationOfLoan)
        {
            var monthToLoan = durationOfLoan * 12;
            return totalLoan / monthToLoan;
        }

        private double CalculateInterestRate(double loanAmount, int yearsOfLoan)
        {
            var interestRate = LoanConfig.AnnualInterestRate/100;
            var monthlyRate = interestRate / (double)12 ;
            var totalMonths = yearsOfLoan * 12;

            var total =  loanAmount * Math.Pow(1 + monthlyRate, totalMonths);

            return total - loanAmount;
        }

        private double CalculateAdministrationFee(double amount)
        {
            if (amount < LoanConfig.AdministrationFeeValue)
            {
                return LoanConfig.AdministrationFeeValue;
            }
            else
            {
                return amount * (LoanConfig.AdministrationFeePercent / 100);
            }
        }
    }
}
