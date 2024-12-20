using HotelLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models
{
    public class Invoice : IInvoice
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public DateTime CreateDate { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public int BookingID { get; set; }

        public Invoice()
        {
            CreateDate = new DateTime();
            CreateDate = DateTime.Now;

            DueDate = new DateTime();
            DueDate = DateTime.Now.AddDays(30);
        }
    }
}
