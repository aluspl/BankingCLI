using CommandLine;

namespace BankingCLI.Common.Config
{
    public class Parameters
    {
        [Option('a', "amount", Required = true, HelpText ="Loan Amount.")]
        public double Amount { get; set; }

        [Option('d', "duration", Required = true, HelpText = "Duration of loan (in years).")]
        public int Duration { get; set; }
    }
}
