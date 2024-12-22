using Hotel.src.ModelManagement.Interfaces;
using Hotel.src.ModelManagement.Services.Interfaces;
using HotelLibrary.Utilities.UserInputManagement;

namespace Hotel.src.ModelManagement.Services
{
    public class AddressService : IAddressService
    {
        public static IAddress CreateAddress()
        {
            Console.WriteLine("\nLand: ");
            string _country = UserInputHandler.UserInputString();
            Console.Write("\nStad: ");
            string _city = UserInputHandler.UserInputString();
            Console.Write("\nPostnummer: ");
            string _postalNumber = UserInputHandler.UserInputString();
            Console.Write("\nGatuadress: ");
            string _streetAddress = UserInputHandler.UserInputString();

            return new Address(_country, _city, _postalNumber, _streetAddress);

        }
        public string GetAddress()
        {
            throw new NotImplementedException();
        }
    }
}
