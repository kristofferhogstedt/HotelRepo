using Hotel.src.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class Exit
    {
        public static void ExitProgram()
        {
            Console.WriteLine("Programmet avslutas...");
            DatabaseLair.CloseConnection();
            Environment.Exit(0);
        }
    }
}
