using HotelLibrary.Models;
using HotelLibrary.Models.Interfaces;
using HotelLibrary.Services.Interfaces;
using HotelLibrary.Utilities.UserInputManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Services
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
