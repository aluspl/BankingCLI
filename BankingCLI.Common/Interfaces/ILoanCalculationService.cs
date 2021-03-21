using BankingCLI.Common.Models;

namespace BankingCLI.Common.Interfaces
{
    public interface ILoanCalculationService
    {
        LoanResultServiceModel CalculateLoan(LoanCalculationServiceModel serviceModel);
    }
}
