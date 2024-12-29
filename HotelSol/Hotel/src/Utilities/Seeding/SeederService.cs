using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Utilities.Seeding
{
    public class SeederService
    {
        public static void Message(string type, bool IsOK)
        {
            if (IsOK)
                Console.WriteLine($"{type} Seeding is successful.");
            else
                Console.WriteLine($"{type} Seeding is unsuccessful.");
        }
    }
}
