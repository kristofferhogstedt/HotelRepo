using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Utilities.Checkers
{
    public class ObjectReferenceChecker
    {
        public static bool IsNull(object obj)
        {
            return obj == null;
        }
    }
}
