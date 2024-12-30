using Hotel.Enums;
using Hotel.src.ModelManagement.Models;
using Hotel.src.Utilities.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
