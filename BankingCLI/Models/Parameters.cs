using CommandLine;

namespace BankingCLI.Models
{
    public class Parameters
    {
        [Option('a', "amount", Required = true, HelpText ="Loan Amount.")]
        public decimal Amount { get; set; }

        [Option('d', "duration", Required = true, HelpText = "Duration of loan (in years).")]
        public int Duration { get; set; }
    }
}
