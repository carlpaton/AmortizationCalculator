namespace AmortizationCalculator.Models
{
    public class PeriodDataModel
    {
        public int Period { set; get; }
        public double EndOfPeriodBalance { set; get; }
        public double InterestPaid { set; get; }
        public double PrincipalPaid { set; get; }
    }
}
