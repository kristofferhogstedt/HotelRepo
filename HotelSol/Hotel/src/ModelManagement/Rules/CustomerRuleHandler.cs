using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Rules
{
    public class CustomerRuleHandler
    {
        public static bool ValidateFirstNameLength(string input)
        {
            if (input.Length < 3)
            {
                return false;
            }
            return true;
        }
    }
}
