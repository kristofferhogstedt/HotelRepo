namespace Hotel.src.ModelManagement.Utilities.Calculators
{
    public class PriceCalculator
    {
        public static double CalculateStayPrice(int nightsBooked, double pricePerNight)
        {
            return nightsBooked * pricePerNight;
        }
    }
}
