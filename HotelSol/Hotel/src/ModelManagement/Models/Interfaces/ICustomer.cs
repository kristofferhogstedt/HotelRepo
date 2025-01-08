using Hotel.src.ModelManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface ICustomer : IModel
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        DateTime DateOfBirth { get; set; }
        string StreetAddress { get; set; }
        string PostalCode { get; set; }
        string City { get; set; }
        string Country { get; set; }
        List<Booking>? Bookings { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        public bool IsInactive { get; set; }
        public DateTime? InactivatedDate { get; set; }


        //-------------------------------------
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        [NotMapped]
        public ushort Age => Convert.ToUInt16(DateTime.Now - DateOfBirth);
        [NotMapped]
        public string Info => $"Namn: {FullName}, Epost: {Email}, Telefon: {Phone}";
        public int NumberOfBookings { get; }
    }
}