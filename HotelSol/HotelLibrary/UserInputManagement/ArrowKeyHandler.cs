using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary.UserInputManagement
{
    public static class ArrowKeyHandler
    {
        public static EUserInputKeys UserInputArrowKey()
        {
            while (true)
            {
                var _consoleKey = Console.ReadKey(true).Key;

                switch (_consoleKey)
                {
                    case ConsoleKey.UpArrow:
                        return EUserInputKeys.Up;
                    case ConsoleKey.DownArrow:
                        return EUserInputKeys.Down;
                    case ConsoleKey.Enter:
                        return EUserInputKeys.Enter;
                    default:
                        return EUserInputKeys.None;
                }
            }
        }

        public static void MoveCursor()
        {

        }
    }
}
