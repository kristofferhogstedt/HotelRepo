using HotelLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models
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
