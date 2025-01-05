using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Utilities.Calculators
{
    public class StayPriceCalculator
    {
        public static double CalculateStayPrice(int nightsBooked, double pricePerNight)
        {
            return nightsBooked * pricePerNight;
        }
    }
}
