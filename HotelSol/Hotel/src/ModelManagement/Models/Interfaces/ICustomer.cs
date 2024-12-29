using Hotel.src.ModelManagement.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface ICustomer
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        DateTime DateOfBirth { get; set; }
        Address Address { get; set; }
        List<Booking> Bookings { get; set; }
        bool IsActive { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        [NotMapped]
        public ushort Age => Convert.ToUInt16(DateTime.Now - DateOfBirth);
        [NotMapped]
        public string Info => $"Namn: {FullName}, Epost: {Email}, Telefon: {Phone}";
    }
}