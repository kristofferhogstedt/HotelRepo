using Hotel.src.ModelManagement.Interfaces;

namespace Hotel.src.ModelManagement.Models
{
    public class Address : IAddress
    {
        public int ID { get; set; }
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
