using Hotel.src.ModelManagement.Interfaces;

namespace Hotel.src.ModelManagement.Data
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
