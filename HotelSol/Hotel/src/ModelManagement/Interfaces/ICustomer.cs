using Hotel.src.ModelManagement.Models;

namespace Hotel.src.ModelManagement.Interfaces
{
    public interface ICustomer
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Address Address { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        List<Booking> Bookings { get; set; }
    }
}