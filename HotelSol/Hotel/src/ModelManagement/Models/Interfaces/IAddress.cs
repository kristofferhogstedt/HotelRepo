namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IAddress : IModel
    {
        int ID { get; set; }
        string StreetAddress { get; set; }
        string PostalCode { get; set; }
        string Country { get; set; }
        string City { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? InactivatedDate { get; set; }
    }
}
