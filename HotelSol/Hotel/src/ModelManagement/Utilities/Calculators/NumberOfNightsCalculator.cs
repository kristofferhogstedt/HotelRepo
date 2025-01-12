using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Utilities.Calculators
{
    public class NumberOfNightsCalculator
    {
        public static int CalculateNumberOfNights(DateTime toDate, DateTime fromDate)
        {
            return DateTime.Compare(toDate, fromDate);
        }
    }
}
