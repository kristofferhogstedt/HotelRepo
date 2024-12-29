namespace Hotel.src.ModelManagement.Models.Interfaces
{
    public interface IBooking
    {
        int ID { get; set; }
        int CustomerID { get; set; }
        int EmployeeID { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        bool IsActive { get; set; }
    }
}
