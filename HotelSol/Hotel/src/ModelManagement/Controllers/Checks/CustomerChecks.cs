using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers.Checks
{
    public class CustomerChecks
    {
        public static bool HasBooking(ICustomer customer)
        {
            return customer.Bookings.Any();
        }
    }
}
