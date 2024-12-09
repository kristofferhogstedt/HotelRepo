using HotelLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Services.Interfaces
{
    public interface ICustomerService
    {

        string GetFullName();
        List<IInvoice> GetInvoices();
    }
}
