using Hotel.src.ModelManagement.Controllers;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models
{
    public class Address_DELETE //: IAddress, IControllableModel // ISupportModel
    {
        [Key]
        public int ID { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<ICustomer> Customers { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }

        [NotMapped]
        public static EModelType ModelTypeEnum { get; set; } = EModelType.Address;

        //[NotMapped]
        //public static Type ModelType { get; set; } = typeof(Address);
        //[NotMapped]
        //public static Type ControllerType { get; set; } = typeof(AddressController);
        //[NotMapped]
        //public static Type ServiceType { get; set; } = typeof(AddressService);

        public string Info => throw new NotImplementedException();

        //public Address()
        //{
        //    CreatedDate = DateTime.Now;
        //}

        //public Address(string country, string city, string postalCode, string streetAddress)
        //{
        //    Country = country;
        //    City = city;
        //    PostalCode = postalCode;
        //    StreetAddress = streetAddress;
        //    CreatedDate = DateTime.Now;
        //}
    }
}
