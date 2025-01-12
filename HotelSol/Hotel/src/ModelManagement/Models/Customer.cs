using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models
{
    public class Customer : ICustomer
    {
        [Key]
        public int ID { get; set; }
        //-------------------------------------
        public List<Booking>? Bookings { get; set; }
        //-------------------------------------

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime? InactivatedDate { get; set; }

        //-------------------------------------
        [NotMapped]
        public EModelType ModelTypeEnum { get; set; } = EModelType.Customer;
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        [NotMapped]
        public ushort Age => Convert.ToUInt16(DateTime.Now - DateOfBirth);
        [NotMapped]
        public string Info => $"{FullName}      |       {Email}     |       {Phone}";
        [NotMapped]
        public int NumberOfBookings
        {
            get
            {
                if (Bookings != null)
                    return Bookings.Count;
                else
                    return 0;
            }
        }
        //-------------------------------------

        public Customer()
        {
            CreatedDate = DateTime.Now;
        }
        public Customer(string firstName, string lastName, DateTime dateOfBirth, string email, string phone, string streetAddress, string postalCode, string city, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            Phone = phone;
            StreetAddress = streetAddress;
            PostalCode = postalCode;
            City = city;
            Country = country;
            CreatedDate = DateTime.Now;
        }
    }
}
