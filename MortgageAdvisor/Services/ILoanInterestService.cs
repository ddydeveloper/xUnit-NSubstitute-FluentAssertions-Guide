using System;

namespace MortgageAdviser.Services
{
    public interface ILoanInterestService
    {
        decimal GetLoanInterest(DateTime birthDate, int yearsToPay);
    }

    public class LoanInterestService : ILoanInterestService
    {
        public decimal GetLoanInterest(DateTime birthDate, int yearsToPay)
        {
            if (yearsToPay <= 1) throw new ArgumentException($"Payment period is too short: {yearsToPay} years.");

            var ageInDays = (DateTime.Now.Date - birthDate.Date).TotalDays;
            var ageInYears = Math.Truncate(ageInDays / 365);
            if (ageInYears > 90)
                throw new InvalidOperationException(
                    $"Loan interest can't be count due to age: {ageInYears} years old.");

            var loanInterest = 1.8m;
            if (ageInYears < 30) loanInterest -= 0.2m;

            if (yearsToPay <= 20) loanInterest -= 0.2m;

            if (yearsToPay <= 10) loanInterest -= 0.2m;

            return loanInterest;
        }
    }
}