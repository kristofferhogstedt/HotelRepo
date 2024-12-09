using HotelLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models
{
    public class Address : IAddress
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetName { get; set; }

        public Address(string country, string city, string postalCode, string streetAddress)
        {
            Country = country;
            City = city;
            PostalCode = postalCode;
            StreetName = streetAddress;
        }
    }
}
