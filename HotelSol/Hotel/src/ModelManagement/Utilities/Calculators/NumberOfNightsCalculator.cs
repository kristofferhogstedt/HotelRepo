using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Utilities.Calculators
{
    public class NumberOfNightsCalculator
    {
        public static int calculateNumberOfNights(DateTime fromDate, DateTime toDate)
        {
            return DateTime.Compare(toDate, fromDate);
        }
    }
}
