using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models.Interfaces
{
    public interface IInvoice
    {
        int InvoiceID { get; set; }
        int CustomerID { get; set; }
        DateTime InvoiceDate { get; set; }
        double Amount { get; set; }
        DateTime DueDate { get; set; }
        bool IsPaid { get; set; }
    }
}
