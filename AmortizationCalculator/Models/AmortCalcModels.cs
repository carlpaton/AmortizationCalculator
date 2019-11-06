namespace AmortizationCalculator.Models
{
    public class AmortCalcModel
    {
        /// <summary>
        /// Loan term in months, example : 36
        /// </summary>
        public int TermInMonths { get; set; }

        /// <summary>
        /// The purchase price
        /// </summary>
        public double PrincipalLoanAmount { get; set; }

        public double Deposit { get; set; }

        public double AnnualInterestRate { get; set; }

        public PaymentFrequencyTypes PaymentFrequency { get; set; }
    }

    public enum PaymentFrequencyTypes
    {
        Monthly,
        //Fortnightly,
        //Weekly
    }
}
