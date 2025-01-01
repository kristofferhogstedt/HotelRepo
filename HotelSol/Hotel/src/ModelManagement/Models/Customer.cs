using Hotel.src.ModelManagement.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.src.ModelManagement.Models
{
    public class Customer : ICustomer
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public List<Booking>? Bookings { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        [NotMapped]
        public ushort Age => Convert.ToUInt16(DateTime.Now - DateOfBirth);
        [NotMapped]
        public string Info => $"Namn: {FullName}, Epost: {Email}, Telefon: {Phone}";


        public Customer()
        {
        }
        public Customer(string firstName, string lastName, DateTime dateOfBirth, string email, string phone, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
} 
