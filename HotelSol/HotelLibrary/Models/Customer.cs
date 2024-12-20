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
        public Address Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Booking> Bookings { get; set; }

        public Customer() 
        {
        }
        public Customer(int id, string firstName, string lastName, string email, string phone, Address address)
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
