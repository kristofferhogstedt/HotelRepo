
using HotelLibrary;
using HotelLibrary.Interfaces;

namespace Hotel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IClass _myClass = new Class();
            _myClass.ProcessData();

            Console.ReadKey();

        }
    }

    // Att göra:
    // DI with AutoFac, Tim Corey https://www.youtube.com/watch?v=mCUNrRtVVWY
    // Använd primary constructor för dependency injection
}
