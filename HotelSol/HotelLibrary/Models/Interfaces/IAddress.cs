using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.Models.Interfaces
{
    public interface IAddress
    {
        string Country { get; set; }
        string City { get; set; }
        string PostalCode { get; set; }
        string StreetName { get; set; }

    }
}
