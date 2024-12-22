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
    public class CustomerService : ICustomerService
    {
        ICustomerService _instance;

        ICustomerService GetInstance()
        {
            if (_instance == null)
                _instance = new CustomerService();
            return _instance;
        }

        public static void CreateCustomer(ICustomer newCustomer)
        {
            
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
