using System;
using MortgageAdviser.Services;
using Xunit;

namespace MortgageAdvisorTests.Services
{
    public class LoanInterestServiceTests
    {
        private readonly ILoanInterestService _loanInterest = new LoanInterestService();

        [Theory]
        [InlineData(1990, 30, "1.8")]
        [InlineData(1988, 20, "1.6")]
        [InlineData(1986, 10, "1.4")]
        [InlineData(2003, 10, "1.2")]
        public void GetLoanInterest_ReturnsDefaultInterest(int birthYear, int yearsToPay, string expectedInterestString)
        {
            // Arrange
            var birthDate = new DateTime(birthYear, 1, 1);
            var expectedInterest = Convert.ToDecimal(expectedInterestString);

            // Act
            var loanInterest = _loanInterest.GetLoanInterest(birthDate, yearsToPay);

            // Assert
            Assert.True(loanInterest == expectedInterest);
        }
    }
}