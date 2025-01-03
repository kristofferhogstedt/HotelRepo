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
    // RoomDetail seeded through RoomSeeder


    //public class RoomDetailSeeder : ISeedable
    //{
    //    public static void Seed()
    //    {
    //        if (DatabaseLair.DatabaseContext.RoomDetails.Any())
    //        {
    //            return;   // DB already contains data
    //        }

    //        var _seededModels = RoomDetailSeeder.CreateSeed(4);
    //        foreach (var entity in _seededModels)
    //        {
    //            DatabaseLair.DatabaseContext.RoomDetails.Add(entity);
    //        }

    //        DatabaseLair.DatabaseContext.SaveChanges();
    //    }

    //    private static List<RoomDetail> CreateSeed(int amount)
    //    {
    //        var _roomTypes = new List<RoomDetail>()
    //        {
    //            new RoomDetail{Type=ERoomType.Single},
    //        };

    //        return _roomTypes;
    //    }
    //}
}
