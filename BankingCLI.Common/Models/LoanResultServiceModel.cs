namespace BankingCLI.Common.Models
{
    public class LoanResultServiceModel
    {
        public double MonthlyPayment { get; set; }

        public double AdministrationFee { get; set; }

        public double InterestRate { get; set; }

        public double LoanAmount { get; set; }

        public int DurationOfLoan { get; set; }

        public double TotalLoanAmount { get; set; }
    }
}
