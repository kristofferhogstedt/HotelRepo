using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models.Interfaces
{
    public interface IBooking
    {
        int Id { get; }
        //int CustomerID { get; set; }
        //int RoomID { get; set; }
        //int InvoiceID { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
    }
}
