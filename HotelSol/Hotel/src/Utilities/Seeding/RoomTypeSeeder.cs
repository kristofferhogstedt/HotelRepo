using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
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
            if (DatabaseLair.DatabaseContext.RoomTypes.Any())
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
                new RoomType(){Name="Single", NumberOfBedsDefault=-1, NumberOfBedsMax=-1, SizeDefault=-1, SizeMax=-1, PriceDefault=800},
                new RoomType(){Name="Double", NumberOfBedsDefault=-1, NumberOfBedsMax=-1, SizeDefault=-1, SizeMax=-1, PriceDefault=1000},
                new RoomType(){Name="Family", NumberOfBedsDefault=-1, NumberOfBedsMax=-1, SizeDefault=-1, SizeMax=-1, PriceDefault=1500},
                new RoomType(){Name="Suite", NumberOfBedsDefault=-1, NumberOfBedsMax=-1, SizeDefault=-1, SizeMax=-1, PriceDefault=2500}
            };

            return _roomTypes;
        }
    }
}
