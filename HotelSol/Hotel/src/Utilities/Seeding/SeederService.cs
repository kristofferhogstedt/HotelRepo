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
