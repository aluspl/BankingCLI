using System.Text;
using BankingCLI.Common.Interfaces;
using BankingCLI.Common.Models;

namespace BankingCLI.Services.LoanCalculation
{
    public class LoanReportService : ILoanReportService
    {
        public string GenerateReport(LoanResultServiceModel serviceModel)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Input:");

            stringBuilder.AppendLine($"Loan Amount:");
            stringBuilder.AppendLine($"{serviceModel.LoanAmount:#}");

            stringBuilder.AppendLine($"Duration of Loan:");
            stringBuilder.AppendLine($"{serviceModel.DurationOfLoan:#}");

            stringBuilder.AppendLine($"Output:");
            stringBuilder.AppendLine($"Total Loan Amount:");
            stringBuilder.AppendLine($"{serviceModel.TotalLoanAmount:#}");

            stringBuilder.AppendLine($"Interest Rate:");
            stringBuilder.AppendLine($"{serviceModel.InterestRate:#}");

            stringBuilder.AppendLine($"Monthly Payment:");
            stringBuilder.AppendLine($"{serviceModel.MonthlyPayment:#}");

            stringBuilder.AppendLine($"Administration Fee:");
            stringBuilder.AppendLine($"{serviceModel.AdministrationFee:#}");

            return stringBuilder.ToString();
        }
    }
}
