using Hotel.src.ModelManagement.Interfaces;

namespace Hotel.src.ModelManagement.Models
{
    public class Customer : ICustomer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Booking>? Bookings { get; set; }

        public Customer()
        {
        }
        public Customer(string firstName, string lastName, string email, string phone, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
} 
