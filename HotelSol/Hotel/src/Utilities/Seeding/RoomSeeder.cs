using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.Persistence;
using Hotel.src.Utilities.Seeding.Interfaces;

namespace Hotel.src.Utilities.Seeding
{
    public class RoomSeeder : ISeedable
    {
        //public static void Seed()
        //{
        //    if (DatabaseLair.DatabaseContext.Rooms.Any())
        //    {
        //        return;   // DB already contains data
        //    }

        //    var _rooms = CreateSeed();
        //    foreach (var room in _rooms)
        //    {
        //        DatabaseLair.DatabaseContext.Rooms.Add((Room)room);
        //    }

        //    DatabaseLair.DatabaseContext.SaveChanges();
        //}

        /// <summary>
        /// Creates custom seed data (without Bogus NuGet)
        /// </summary>
        /// <returns></returns>
        //public static List<IRoom> CreateSeed()
        //{
        //    var _rooms = new List<IRoom>()
        //    {
        //        new Room{Name="101",Description="Room 101",Detail = new RoomDetail{RoomType = 1, NumberOfBeds=1, Size=15},Floor="1",IsActive=true},
        //        new Room{Name="102",Description="Room 102",Detail = new RoomDetail{TypeID = 2, NumberOfBeds=2, Size=20},Floor="1",IsActive=true},
        //        new Room{Name="103",Description="Room 103",Detail = new RoomDetail{TypeID = 1, NumberOfBeds=1, Size=15},Floor="1",IsActive=true},
        //        new Room{Name="104",Description="Room 104",Detail = new RoomDetail{TypeID = 1, NumberOfBeds=1, Size=15},Floor="1",IsActive=true},
        //        new Room{Name="201",Description="Room 201",Detail = new RoomDetail{TypeID = 1, NumberOfBeds=1, Size=15},Floor="2",IsActive=false},
        //        new Room{Name="202",Description="Room 202",Detail = new RoomDetail{TypeID = 2, NumberOfBeds=2, Size=30},Floor="2",IsActive=true},
        //        new Room{Name="203",Description="Room 203",Detail = new RoomDetail{TypeID = 1, NumberOfBeds=1, Size=15},Floor="2",IsActive=true},
        //        new Room{Name="204",Description="Room 204",Detail = new RoomDetail{TypeID = 3, NumberOfBeds=4, Size=30},Floor="2",IsActive=true},
        //        new Room{Name="301",Description="Room 301",Detail = new RoomDetail{TypeID = 3, NumberOfBeds=5, Size=35},Floor="3",IsActive=true},
        //        new Room{Name="302",Description="Room 302",Detail = new RoomDetail{TypeID = 4, NumberOfBeds=2, Size=45},Floor="3",IsActive=true},
        //    };

        //    return _rooms;
        //}
    }
}
