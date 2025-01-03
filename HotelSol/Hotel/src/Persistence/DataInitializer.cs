using Hotel.src.Utilities.Seeding;

namespace Hotel.src.Persistence
{
    public class DataInitializer
    {
        public static void Initialize()
        {
            StartSeed();
        }

        public static void StartSeed()
        {
            // Customers
            CustomerSeeder.Seed();
            SeederService.Message("Customer", DatabaseLair.DatabaseContext.Customers.Any());

            // Roomtypes and Rooms 
            RoomTypeSeeder.Seed();
            SeederService.Message("RoomType", DatabaseLair.DatabaseContext.RoomTypes.Any());

            RoomSeeder.Seed();
            SeederService.Message("Room", DatabaseLair.DatabaseContext.Rooms.Any());

            // Bookings
            BookingSeeder.Seed();
            SeederService.Message("Booking", DatabaseLair.DatabaseContext.Bookings.Any());

            // Invoices
            InvoiceSeeder.Seed();
            SeederService.Message("Invoice", DatabaseLair.DatabaseContext.Invoices.Any());

        }
    }
}
