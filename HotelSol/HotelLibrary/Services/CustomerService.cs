using HotelLibrary.Models;
using HotelLibrary.Models.Interfaces;
using HotelLibrary.Services.Interfaces;
using HotelLibrary.UserInputManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Services
{
    internal class CustomerService : ICustomerService
    {
        ICustomerService _instance;

        ICustomerService GetInstance()
        {
            if (_instance == null)
                _instance = new CustomerService();
            return _instance;
        }

        public ICustomer CreateCustomer()
        {
            Console.WriteLine("Kundregistrering");
            Console.Write("\nFörNamn: ");
            string _firstName = UserInputHandler.UserInputString();
            Console.Write("\nEfternamn: ");
            string _lastName = UserInputHandler.UserInputString();
            Console.Write("\nE-post: ");
            string _email = UserInputHandler.UserInputString();
            Console.Write("\nTelefon: ");
            string _phoneNumber = UserInputHandler.UserInputString();

            Console.WriteLine("\nAdress: ");
            IAddress _address = AddressService.CreateAddress();

            return new Customer(this.GetID(), _firstName, _lastName, _email, _phoneNumber, _address);
        }

        public string GetFullName()
        {
            throw new NotImplementedException();
        }

        private int GetID()
        {
            return 1;
        }

        public List<IInvoice> GetInvoices()
        {
            throw new NotImplementedException();
        }
    }
}
