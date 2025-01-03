using Hotel.src.ModelManagement.Models;
using Hotel.src.Persistence;
using Hotel.src.Utilities.Seeding.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Utilities.Seeding
{
    public class RoomTypeSeeder : ISeedable
    {
        public static void Seed()
        {
            if (DatabaseLair.DatabaseContext.Bookings.Any())
            {
                return;   // DB already contains data
            }

            var _seededModels = RoomTypeSeeder.CreateSeed(4);
            foreach (var entity in _seededModels)
            {
                DatabaseLair.DatabaseContext.RoomTypes.Add(entity);
            }

            DatabaseLair.DatabaseContext.SaveChanges();
        }

        private static List<RoomType> CreateSeed(int amount)
        {
            var _roomTypes = new List<RoomType>()
            {
                new RoomType{Name="Single"},
                new RoomType{Name="Double"},
                new RoomType{Name="Family"},
                new RoomType{Name="Suite"}
            };

            return _roomTypes;
        }
    }
}
