using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers
{
    public class InvoiceController : IInvoiceController
    {
        public static IInvoiceController _instance;
        IInvoice _invoice;
        public InvoiceController(IInvoice invoice) 
        {
            _invoice = invoice;
        }

        public static IInvoiceController GetInstance()
        {
            if (_instance == null)
                _instance = new InvoiceController(new Invoice());
            return _instance;
        }
    }
}
