using System;

namespace MortgageAdviser.Services
{
    public interface IMortgageService
    {
        (decimal, decimal) GetAmountAndMonthlyPayment(decimal loanInterest, decimal annualIncome, int yearsToPay);
    }

    public class MortgageService : IMortgageService
    {
        public (decimal, decimal) GetAmountAndMonthlyPayment(decimal loanInterest, decimal annualIncome, int yearsToPay)
        {
            throw new NotImplementedException();
        }
    }
}