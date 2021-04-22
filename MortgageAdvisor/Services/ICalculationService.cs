using System;
using MortgageAdviser.Models;

namespace MortgageAdviser.Services
{
    public interface ICalculationService
    {
        MortgageCalculation GetCalculation(DateTime birthDate, decimal annualIncome, int yearsToPay);
    }

    public class CalculationService : ICalculationService
    {
        private readonly ILoanInterestService _loanInterestService;
        private readonly IMortgageService _mortgageService;
        private readonly IPersonValidator _personValidator;

        public CalculationService(ILoanInterestService loanInterestService, IPersonValidator personValidator,
            IMortgageService mortgageService)
        {
            _loanInterestService = loanInterestService;
            _personValidator = personValidator;
            _mortgageService = mortgageService;
        }

        public MortgageCalculation GetCalculation(DateTime birthDate, decimal annualIncome, int yearsToPay)
        {
            if (!_personValidator.IsValidPerson()) return MortgageCalculation.GetRejectedCalculation();

            var loanInterest = _loanInterestService.GetLoanInterest(birthDate, yearsToPay);
            var (amount, monthlyPayment) =
                _mortgageService.GetAmountAndMonthlyPayment(loanInterest, annualIncome, yearsToPay);

            return MortgageCalculation.GetConfirmedCalculation(amount, monthlyPayment);
        }
    }
}