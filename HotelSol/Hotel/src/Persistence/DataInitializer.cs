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
            CustomerSeeder.Seed();
            SeederService.Message("Customer", DatabaseLair.DatabaseContext.Customers.Any());

            RoomSeeder.Seed();
            SeederService.Message("Room", DatabaseLair.DatabaseContext.Rooms.Any());

            BookingSeeder.Seed();
            SeederService.Message("Booking", DatabaseLair.DatabaseContext.Bookings.Any());

            InvoiceSeeder.Seed();
            SeederService.Message("Invoice", DatabaseLair.DatabaseContext.Invoices.Any());

        }
    }
}
