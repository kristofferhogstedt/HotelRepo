using Hotel;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.Utilities.ConsoleManagement;
using Hotel.src.Utilities.UserInputManagement;
using Microsoft.IdentityModel.Tokens;

namespace HotelLibrary.Utilities.UserInputManagement
{
    public class UserInputHandler
    {

        public static bool UserInputBool(IMenu previousMenu)
        {
            var _input = UserInputString(previousMenu).ToLower();

            switch (_input)
            {
                case "ja":
                case "j":
                case "yes":
                case "y":
                    return true;
                case "nej":
                case "n":
                case "no":
                    return false;
                default:
                    Console.WriteLine("Felaktig inmatning, ange Ja eller Nej.");
                    LineClearer.ClearLastLine(1000);
                    return UserInputBool(previousMenu);
            }
        }

        public static ConsoleKey UserInputEscape(IMenu previousMenu)
        {
            var _key = Console.ReadKey(true).Key;

            if (_key == ConsoleKey.Escape)
            {
                if (previousMenu != null)
                {
                    Console.WriteLine("Återgår...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    previousMenu.Run();
                }
                else
                    Exit.ExitProgram();
                return _key;
            }
            else
            {
                return _key;
            }
        }

        public static bool UserInputEsc(ConsoleKey firstKey)
        {
            if (firstKey == ConsoleKey.Escape)
                return true;
            else
                return false;
        }

        public static bool UserInputEnter(ConsoleKey firstKey)
        {
            if (firstKey == ConsoleKey.Enter)
                return true;
            else
                return false;
        }

        public static string UserInputString(IMenu previousMenu)
        {
            var _firstKey = Console.ReadKey(true).Key; //UserInputEscape(previousMenu);
            string _output = "";

            if (UserInputEsc(_firstKey))
                _output = "";
            else if (UserInputEnter(_firstKey))
                _output = "-1";
            else
                _output = Console.ReadLine();
            return _output;
        }

        public static string UserInputStringNotNullOrEmpty(IMenu previousMenu)
        {
            var _input = "";
            while (_input.IsNullOrEmpty())
            {
                _input = UserInputString(previousMenu);
                if (_input.IsNullOrEmpty())
                {
                    Console.WriteLine("Får inte vara tomt.");
                    LineClearer.ClearLastLine(1000);
                }
            }

            return _input;
        }

        public static int UserInputInt(IMenu previousMenu)
        {
            int _output = -1;
            while (!int.TryParse(UserInputString(previousMenu), out _output))
            {
                Console.WriteLine("Felaktig inmatning, måste vara heltal (int).");
                LineClearer.ClearLastLine(1000);
            }

            return _output;
        }

        public static ushort UserInputUshort(IMenu previousMenu)
        {
            ushort _output = 0;
            while (!ushort.TryParse(UserInputString(previousMenu), out _output))
            {
                Console.WriteLine("Felaktig inmatning, heltal (ushort).");
                LineClearer.ClearLastLine(1000);
            }

            return _output;
        }
    }
}
