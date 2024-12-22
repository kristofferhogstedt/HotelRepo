using Hotel.src.Models.Interfaces;

namespace Hotel.src.Models.Data
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
