using HotelLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models
{
    public class Customer : ICustomer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public IAddress Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<IInvoice> Invoices { get; set; }

        public Customer() 
        {
        }
        public Customer(int id, string firstName, string lastName, string email, string phone, IAddress address)
        {
            CustomerId = id;
            CustomerFirstName = firstName;
            CustomerLastName = lastName;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}
