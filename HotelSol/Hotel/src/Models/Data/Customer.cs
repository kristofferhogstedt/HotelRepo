using Hotel.src.Models.Interfaces;

namespace Hotel.src.Models.Data
{
    public class Customer : ICustomer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Booking> Bookings { get; set; }

        public Customer()
        {
        }
        public Customer(int id, string firstName, string lastName, string email, string phone, Address address)
        {
            CustomerId = id;
            CustomerFirstName = firstName;
            CustomerLastName = lastName;
            Address = address;
            Email = email;
            Phone = phone;
        }
    }
}
