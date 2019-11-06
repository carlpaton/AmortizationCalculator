### ﻿Amortization Calculator

This calculates compound interest for a period of time using the formula `P = (i * Principle x (1 + i)^n) / ((1 + i)^n – 1)` - as this is a known calculation, there are heaps of calculators and examples online in a variety of programming languages. 

The value of this project was for me to understand this functionality. Most of the code was copied from the references listed below.

The examples and the code base currently only has `PaymentFrequencyTypes` for `Monthly` however it is possible to refactor to allow `Fortnightly` and `weekly` 

### Calculate Single Instalment

Where an entire schedule is not needed, given the following:

| Key                   | Value    |
| --------------------- | -------- |
| Annual interest rate  | 5.44%    |
| Term in months        | 360      |
| Payment frequency     | Monthly  |
| Deposit               | 0        |
| Principal loan amount | $820 000 |

The repayment will be **$4 625.05**

![Calculate single instalment](https://carlpaton.github.io/d/amortization-calculator/calculate-single-instalment.jpg)

### Calculate Schedule

Where a schedule is needed showing the period interest payment and reducing principle loan amount:

| Key                   | Value   |
| --------------------- | ------- |
| Annual interest rate  | 5.44%   |
| Term in months        | 3       |
| Payment frequency     | Monthly |
| Deposit               | 0       |
| Principal loan amount | $5 000  |

The repayment will be **$1 681.81**

![Calculate schedule](https://carlpaton.github.io/d/amortization-calculator/calculate-schedule.jpg)

#### References

* https://www.amortization-calc.com/mortgage-calculator/
* https://www.amortization-calc.com/auto-car-loan-calculator/
* https://www.coderslexicon.com/amortization-definitive-c-c-java-etc/
* https://vedpathak.blogspot.com/2012/05/amortization-calculator-in-aspnet-using.html
* https://github.com/jcollins2014/C-.NET-Loan-Amortization-Calculator/blob/main/LoanAmoritizationScheduler/MainWindow.xaml.cs