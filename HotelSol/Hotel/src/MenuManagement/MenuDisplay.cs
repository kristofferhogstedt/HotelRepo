using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement
{
    public class MenuDisplay
    {
        public static void DisplayMenu(Dictionary<int, string> menuToDisplay)
        {
            foreach (var item in menuToDisplay)
            {
                Console.WriteLine($"{item.Key.ToString()}. {item.Value}");
            }
        }
    }
}
