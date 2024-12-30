using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement
{
    public class Exit
    {
        public static void ExitProgram()
        {
            Console.WriteLine("Programmet avslutas...");
            Environment.Exit(0);
        }
    }
}
