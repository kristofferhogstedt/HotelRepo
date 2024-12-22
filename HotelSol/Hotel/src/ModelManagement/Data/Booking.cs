using Hotel.src.ModelManagement.Interfaces;

namespace Hotel.src.ModelManagement.Data
{
    public class Booking : IBooking
    {
        public int Id => throw new NotImplementedException();
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CustomerID { get; set; }
    }
}
