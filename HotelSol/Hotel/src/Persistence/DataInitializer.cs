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
        public static void Initialize(DatabaseLair databaseLair)
        {
            StartSeed(databaseLair);
        }

        public static void StartSeed(DatabaseLair databaseLair)
        {
            CustomerSeeder.Seed(databaseLair);
            SeederService.Message("Customer", databaseLair.DatabaseContext.Customers.Any());

            RoomSeeder.Seed(databaseLair);
            SeederService.Message("Room", databaseLair.DatabaseContext.Rooms.Any());
        }
    }
}
