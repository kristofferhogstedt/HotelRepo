﻿namespace Hotel.src.ModelManagement.Utilities.Messagers
{
    public class ServiceMessager
    {
        public static void DataNotFoundMessage()
        {
            Console.WriteLine("Data not found");
            Console.WriteLine("Returning... ");
            Thread.Sleep(2000);
        }
        public static void SubDataNotFoundMessage()
        {
            Console.WriteLine("SubData not found");
            Console.WriteLine("Returning... ");
            Thread.Sleep(2000);
        }
    }
}
