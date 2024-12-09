using HotelLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models
{
    internal class Invoice : IInvoice
    {
        public int InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public Invoice()
        {
            InvoiceDate = new DateTime();
            InvoiceDate = DateTime.Now;

            DueDate = new DateTime();
            DueDate = DateTime.Now.AddDays(30);
        }
    }
}
