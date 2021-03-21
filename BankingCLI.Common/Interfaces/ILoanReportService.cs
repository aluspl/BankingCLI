using BankingCLI.Common.Models;

namespace BankingCLI.Common.Interfaces
{
    public interface ILoanReportService
    {
        string GenerateReport(LoanResultServiceModel serviceModel);
    }
}
