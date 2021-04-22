using System;
using FluentAssertions;
using FluentAssertions.Execution;
using MortgageAdviser.Services;
using NSubstitute;
using Xunit;

namespace MortgageAdvisorTests.Services
{
    public class CalculationServiceTests
    {
        private readonly ILoanInterestService _loanInterestService = Substitute.For<ILoanInterestService>();
        private readonly IMortgageService _mortgageService = Substitute.For<IMortgageService>();
        private readonly IPersonValidator _personValidator = Substitute.For<IPersonValidator>();
        private readonly ICalculationService _calculationService;

        public CalculationServiceTests()
        {
            _calculationService = new CalculationService(_loanInterestService, _personValidator, _mortgageService);
        }

        [Fact]
        public void GetCalculation_InvalidPerson_Rejects()
        {
            // Arrange

            // Act

            // Assert
        }

        [Theory]
        [InlineData(1983, 42000, 30)]
        [InlineData(1965, 55000, 25)]
        [InlineData(2001, 22000, 15)]
        [InlineData(1996, 18000, 8)]
        public void GetCalculation_ValidPerson_Confirms(int birthYear, int annualIncome, int yearsToPay)
        {
            // Arrange
            const decimal monthlyPayment = 1200;
            const decimal loanInterest = 1.2m;
            var birthDate = new DateTime(birthYear, 1, 1);
            var amount = monthlyPayment * yearsToPay * 12;

            _personValidator
                .IsValidPerson()
                .Returns(true);

            _loanInterestService
                .GetLoanInterest(birthDate, yearsToPay)
                .Returns(loanInterest);

            _mortgageService
                .GetAmountAndMonthlyPayment(1.2m, annualIncome, yearsToPay)
                .Returns((amount, monthlyPayment));

            // Act
            var calculations = _calculationService.GetCalculation(birthDate, annualIncome, yearsToPay);

            // Assert
            _personValidator
                .Received()
                .IsValidPerson();

            _loanInterestService
                .Received()
                .GetLoanInterest(Arg.Any<DateTime>(), yearsToPay);

            _mortgageService
                .ReceivedWithAnyArgs()
                .GetAmountAndMonthlyPayment(default, default, default);

            using (new AssertionScope())
            {
                calculations.Should().NotBeNull();
                calculations.IsPersonAvailable.Should().BeTrue();
                calculations.Amount.Should().Be(amount);
                calculations.MonthlyPayment.Should().Be(monthlyPayment);
            }
        }
    }
}