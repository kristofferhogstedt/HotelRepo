namespace Hotel.src.ModelManagement.Interfaces
{
    public interface IAddress
    {
        int ID { get; set; }
        string Country { get; set; }
        string City { get; set; }
        string PostalCode { get; set; }
        string StreetName { get; set; }

    }
}
