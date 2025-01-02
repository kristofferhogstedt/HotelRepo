using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Utilities.ConsoleManagement
{
    public class LineClearer
    {
        /// <summary>
        /// Clear line instantly
        /// </summary>
        public static void ClearLine()
        {
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
        }
        /// <summary>
        /// Clears line after delay
        /// </summary>
        /// <param name="sleepLength"></param>
        public static void ClearLine(int sleepLength)
        {
            Thread.Sleep(sleepLength);
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
        }

        /// <summary>
        /// Clears previous line instantly
        /// </summary>
        public static void ClearLastLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        /// <summary>
        /// Clears last line after delay
        /// </summary>
        /// <param name="sleepLength"></param>
        public static void ClearLastLine(int sleepLength)
        {
            Thread.Sleep(sleepLength);
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearLine();
        }
    }
}
