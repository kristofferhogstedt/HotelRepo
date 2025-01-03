using Hotel.src.FactoryManagement;
using Hotel.src.FactoryManagement.Interfaces;
using Hotel.src.MenuManagement.Menus.Interfaces;
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
    public class AddressController : ISupportModelController, IInstantiable
    {
        public IMenu PreviousMenu { get; set; }
        public static IInstantiable _instance;
        private static readonly object _lock = new object(); // Lock object for thread safety

        public AddressController()
        {
        }

        /// <summary>
        /// Single instance
        /// </summary>
        /// <returns></returns>
        public static ISupportModelController GetInstance(IMenu previousMenu)
        {
            _instance = InstanceGenerator.GetInstance<AddressController>(_instance, _lock, previousMenu);
            return (ISupportModelController)_instance;

            //if (_instance == null)
            //{
            //    lock (_lock)
            //    {
            //        if (_instance == null)
            //        {
            //            _instance = new AddressController(previousMenu);
            //        }
            //    }
            //}
            //return _instance;
        }

        public ISupportModel Create()
        {
            Console.Clear();
            Console.WriteLine("Adressregistrering");
            Console.Write("\nGatuadress: ");
            string _street = UserInputHandler.UserInputString(PreviousMenu);
            Console.Write("\nPostnummer: ");
            string _zipCode = UserInputHandler.UserInputString(PreviousMenu);
            Console.Write("\nOrt: ");
            string _city = UserInputHandler.UserInputString(PreviousMenu);
            Console.Write("\nLand: ");
            string _country = UserInputHandler.UserInputString(PreviousMenu);

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
