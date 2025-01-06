using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers.Forms.Utilities
{
    public class CopyChecker
    {
        public static bool CheckCopyValue(object value)
        {
            return value.ToString() == "-1";
        }
    }
}
