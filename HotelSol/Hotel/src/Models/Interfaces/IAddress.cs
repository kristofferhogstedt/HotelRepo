namespace Hotel.src.Models.Interfaces
{
    public interface IAddress
    {
        string Country { get; set; }
        string City { get; set; }
        string PostalCode { get; set; }
        string StreetName { get; set; }

    }
}
