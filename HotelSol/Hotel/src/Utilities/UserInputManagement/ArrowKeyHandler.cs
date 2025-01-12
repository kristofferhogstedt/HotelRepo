using HotelLibrary.Utilities.UserInputManagement.Interfaces;

namespace HotelLibrary.Utilities.UserInputManagement
{
    public class ArrowKeyHandler : IUserInput<EUserInputKeys>
    {
        private static ArrowKeyHandler _instance;
        private ArrowKeyHandler()
        {

        }

        /// <summary>
        /// Singleton
        /// </summary>
        /// <returns></returns>
        public static ArrowKeyHandler GetInstance()
        {
            if (_instance == null)
                _instance = new ArrowKeyHandler();
            return _instance;
        }

        public EUserInputKeys Output { get; set; }

        public EUserInputKeys UserInputArrowKey()
        {
            while (true)
            {
                var _consoleKey = Console.ReadKey(true).Key;

                switch (_consoleKey)
                {
                    case ConsoleKey.UpArrow:
                        Output = EUserInputKeys.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        Output = EUserInputKeys.Down;
                        break;
                    case ConsoleKey.Enter:
                        Output = EUserInputKeys.Enter;
                        break;
                    default:
                        Output = EUserInputKeys.None;
                        break;
                }

                return Output;
            }
        }

        public static void MoveCursor()
        {

        }
    }
}
