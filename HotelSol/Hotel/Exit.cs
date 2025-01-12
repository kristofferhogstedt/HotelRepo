using Hotel.src.Persistence;

namespace Hotel
{
    public class Exit
    {
        public static void ExitProgram()
        {
            Console.WriteLine("Programmet avslutas...");
            DatabaseLair.CloseDbConnection();
            Environment.Exit(0);
        }
    }
}
