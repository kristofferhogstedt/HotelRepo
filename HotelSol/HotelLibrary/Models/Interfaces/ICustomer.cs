namespace HotelLibrary.Models.Interfaces
{
    public interface ICustomer
    {
        int CustomerId { get; set; }
        string CustomerName { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
    }
}