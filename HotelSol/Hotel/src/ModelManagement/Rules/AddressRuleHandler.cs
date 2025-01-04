using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Rules
{
    public class AddressRuleHandler
    {
        public static bool ValidateStreetAddressLength(string input)
        {
            if (input.Length < 3)
            {
                return false;
            }
            return true;
        }
    }
}
