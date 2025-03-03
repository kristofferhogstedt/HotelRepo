﻿using Hotel;
using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.Utilities.ConsoleManagement;
using Microsoft.IdentityModel.Tokens;

namespace HotelLibrary.Utilities.UserInputManagement
{
    public class UserInputHandler
    {
        public static bool UserInputBool(IMenu previousMenu)
        {
            while (true)
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
                        continue;
                }
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
            var _firstKey = Console.ReadKey(true).Key; 
            string _output = "";

            if (UserInputEsc(_firstKey))
                previousMenu.Run();
            else if (UserInputEnter(_firstKey))
                _output = "-1";
            else
                _output = Console.ReadLine();
            return _output;
        }


        public static string UserInputStringNotNullOrEmpty(IMenu previousMenu)
        {
            var _input = "-1";
            while (_input.IsNullOrEmpty() || _input == "-1")
            {
                _input = UserInputString(previousMenu);
                if (_input.IsNullOrEmpty() || _input == "-1")
                {
                    Console.WriteLine("Får inte vara tomt.");
                    LineClearer.ClearLine(1000);
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
                LineClearer.ClearLastLine(1500);
            }

            return _output;
        }

        public static double UserInputDouble(IMenu previousMenu)
        {
            double _output = -1;
            while (!double.TryParse(UserInputString(previousMenu), out _output))
            {
                Console.WriteLine("Felaktig inmatning, måste vara heltal (double).");
            }

            return _output;
        }

        public static ushort UserInputUshort(IMenu previousMenu)
        {
            ushort _output = 0;
            while (!ushort.TryParse(UserInputString(previousMenu), out _output))
            {
                Console.WriteLine("Felaktig inmatning, heltal (ushort).");
            }

            return _output;
        }
    }
}
