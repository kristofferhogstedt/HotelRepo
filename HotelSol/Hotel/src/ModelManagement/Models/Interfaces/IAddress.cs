namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IAddress
    {
        int ID { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string PostalCode { get; set; }
        string StreetAddress { get; set; }
    }
}
