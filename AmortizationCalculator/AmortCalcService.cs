using AmortizationCalculator.Models;
using System;
using System.Collections.Generic;

namespace AmortizationCalculator
{
    public class AmortCalcService : IAmortCalcService
    {
        public double CalculateSingleInstalment(AmortCalcModel model)
        {
            var calculatedPrincipalLoanAmount = model.PrincipalLoanAmount - model.Deposit;
            var interestRate = (model.AnnualInterestRate / 100) / 12;
            var power = Math.Pow((1 + interestRate), model.TermInMonths);
            var instalment = calculatedPrincipalLoanAmount * power * interestRate / (power - 1);

            return Math.Round(instalment, 2);
        }

        public List<PeriodDataModel> CalculateSchedule(AmortCalcModel model)
        {
            var terms = model.TermInMonths;
            var unpaidPrincipalBalance = model.PrincipalLoanAmount;
            var interestRate = model.AnnualInterestRate;
            var monthlyIntRate = ((interestRate / 100) / 12);

            var schedule = new List<PeriodDataModel>
            {
                new PeriodDataModel() 
                {
                    EndOfPeriodBalance = unpaidPrincipalBalance 
                }
            };

            for (int i = 1; i <= terms; i++)
            {
                var lastPeriod = schedule[i - 1];
                var interestPaid = lastPeriod.EndOfPeriodBalance * monthlyIntRate;

                var power = (double)Math.Pow(1.0 + (double)monthlyIntRate, terms - i + 1);
                var principalPaid = (lastPeriod.EndOfPeriodBalance * monthlyIntRate * power / (power - 1)) - interestPaid;
                var endBalance = lastPeriod.EndOfPeriodBalance - principalPaid;

                schedule.Add(new PeriodDataModel()
                {
                    Period = i,
                    EndOfPeriodBalance = Math.Round(endBalance, 2),
                    InterestPaid = Math.Round(interestPaid, 2),
                    PrincipalPaid = Math.Round(principalPaid, 2)
                });
            }

            return schedule;
        }
    }
}
