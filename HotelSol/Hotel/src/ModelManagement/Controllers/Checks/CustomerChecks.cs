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
        public static bool CustomerIsNotNull(ICustomer customer)
        {
            return customer != null;
        }
        public static bool HasBooking(ICustomer customer)
        {
            return customer.Bookings.Any();
        }

        public static bool EmailIsValid(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        public static bool EmailIsUnique(string email, List<ICustomer> customers)
        {
            return customers.Any(c => c.Email == email);
        }

        public static bool PhoneIsValid(string phone)
        {
            // Needs work, check with regex
            return phone.Length == 10;
        }

        public static bool PhoneIsUnique(string phone, List<ICustomer> customers)
        {
            return customers.Any(c => c.Phone == phone);
        }
    }
}
