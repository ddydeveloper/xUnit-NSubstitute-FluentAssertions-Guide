namespace MortgageAdviser.Models
{
    public class MortgageCalculation
    {
        public MortgageCalculation(bool isPersonAvailable, decimal? amount, decimal? monthlyPayment)
        {
            IsPersonAvailable = isPersonAvailable;
            Amount = amount;
            MonthlyPayment = monthlyPayment;
        }

        public bool IsPersonAvailable { get; }
        public decimal? Amount { get; }
        public decimal? MonthlyPayment { get; }

        public static MortgageCalculation GetRejectedCalculation()
        {
            return new(false, null, null);
        }

        public static MortgageCalculation GetConfirmedCalculation(decimal amount, decimal monthlyPayment)
        {
            return new(true, amount, monthlyPayment);
        }
    }
}