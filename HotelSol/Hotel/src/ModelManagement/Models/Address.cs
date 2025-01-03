using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models
{
    public class Address : IAddress, ISupportModel
    {
        [Key]
        public int ID { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }
        [NotMapped]
        public EModelType ModelType { get; set; } = EModelType.Address;

        public string Info => throw new NotImplementedException();

        public Address()
        {
            CreatedDate = DateTime.Now;
        }

        public Address(string country, string city, string postalCode, string streetAddress)
        {
            Country = country;
            City = city;
            PostalCode = postalCode;
            StreetAddress = streetAddress;
            CreatedDate = DateTime.Now;
        }
    }
}
