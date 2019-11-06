using AmortizationCalculator.Models;
using System.Collections.Generic;

namespace AmortizationCalculator
{
    public interface IAmortCalcService
    {
        double CalculateSingleInstalment(AmortCalcModel model);

        List<PeriodDataModel> CalculateSchedule(AmortCalcModel model);
    }
}
