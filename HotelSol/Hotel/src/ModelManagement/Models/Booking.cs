using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.ModelManagement.Models
{
    public class Booking : IBooking
    {
        public int ID { get; }
        public int CustomerID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
