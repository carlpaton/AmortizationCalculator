using AmortizationCalculator;
using AmortizationCalculator.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTests
{
    public class AmortCalcServiceTests
    {
        [TestCase(4625.05, 0)]
        [TestCase(4596.85, 5000)]
        public void CalculateSingleInstalment_valid_inputs_should_return_instalment(double expected, double deposit)
        {
            // Arrange
            IAmortCalcService classUnderTest = new AmortCalcService();
            var amortCalcModel = new AmortCalcModel()
            {
                AnnualInterestRate = 5.44,
                TermInMonths = 360,
                PaymentFrequency = PaymentFrequencyTypes.Monthly,
                Deposit = deposit,
                PrincipalLoanAmount = 820000
            };

            // Act
            var actual = classUnderTest.CalculateSingleInstalment(amortCalcModel);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateSchedule_valid_inputs_should_return_schedule()
        {
            // Arrange
            IAmortCalcService classUnderTest = new AmortCalcService();
            var amortCalcModel = new AmortCalcModel()
            {
                AnnualInterestRate = 5.44,
                TermInMonths = 3,
                PaymentFrequency = PaymentFrequencyTypes.Monthly,
                Deposit = 0,
                PrincipalLoanAmount = 5000
            };
            var expected = new List<PeriodDataModel>() 
            {
                new PeriodDataModel()
                {
                    EndOfPeriodBalance = 5000,
                    InterestPaid = 0,
                    Period = 0,
                    PrincipalPaid = 0
                },
                new PeriodDataModel()
                {
                    EndOfPeriodBalance = 3340.87,
                    InterestPaid = 22.67,
                    Period = 1,
                    PrincipalPaid = 1659.13
                },
                new PeriodDataModel()
                {
                    EndOfPeriodBalance = 1674.21,
                    InterestPaid = 15.15,
                    Period = 2,
                    PrincipalPaid = 1666.66
                },
                new PeriodDataModel()
                {
                    EndOfPeriodBalance = 0,
                    InterestPaid = 7.59,
                    Period = 3,
                    PrincipalPaid = 1674.21
                }
            };

            // Act
            var actual = classUnderTest.CalculateSchedule(amortCalcModel);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
