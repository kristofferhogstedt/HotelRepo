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

        public DateTime CreateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime UpdateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime FromDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime ToDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
