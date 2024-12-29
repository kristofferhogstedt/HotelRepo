using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.ModelManagement.Models
{
    public class Address : IAddress
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetAddress { get; set; }

        public Address(string country, string city, string postalCode, string streetAddress)
        {
            Country = country;
            City = city;
            PostalCode = postalCode;
            StreetAddress = streetAddress;
        }
    }
}
