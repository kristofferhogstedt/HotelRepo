using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using HotelLibrary.Utilities.UserInputManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers
{
    public class AddressController : ISupportModelController
    {
        public static ISupportModelController _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety

        /// <summary>
        /// Single instance
        /// </summary>
        /// <returns></returns>
        public static ISupportModelController GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AddressController();
                    }
                }
            }
            return _instance;
        }

        public ISupportModel Create()
        {
            Console.Clear();
            Console.WriteLine("Adressregistrering");
            Console.Write("\nGatuadress: ");
            string _street = UserInputHandler.UserInputString();
            Console.Write("\nPostnummer: ");
            string _zipCode = UserInputHandler.UserInputString();
            Console.Write("\nOrt: ");
            string _city = UserInputHandler.UserInputString();
            Console.Write("\nLand: ");
            string _country = UserInputHandler.UserInputString();

            return new Address(_street, _zipCode, _city, _country);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
