using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Persistence;
using Hotel.src.Utilities.Seeding.Interfaces;

namespace Hotel.src.Utilities.Seeding
{
    public class RoomSeeder : ISeedable
    {
        public static void Seed()
        {
            if (DatabaseLair.DatabaseContext.Rooms.Any())
            {
                return;   // DB already contains data
            }

            var _rooms = CreateSeed();
            foreach (var room in _rooms)
            {
                DatabaseLair.DatabaseContext.Rooms.Add((Room)room);
            }

            DatabaseLair.DatabaseContext.SaveChanges();
        }

        /// <summary>
        /// Creates custom seed data(without Bogus NuGet)
        /// </summary>
        /// <returns></returns>
        public static List<IRoom> CreateSeed()
        {
            var _rooms = new List<IRoom>()
            {
                new Room{Name="101",Description="Room 101",Details = new RoomDetail{RoomType = (RoomType)RoomTypeService.GetOneByRoomType("Single"), NumberOfBeds=1, Size=15},Floor="1"},
                new Room{Name="102",Description="Room 102",Details = new RoomDetail{RoomType = (RoomType)RoomTypeService.GetOneByRoomType("Double"), NumberOfBeds=2, Size=20},Floor="1"},
                new Room{Name="103",Description="Room 103",Details = new RoomDetail{RoomType = (RoomType)RoomTypeService.GetOneByRoomType("Single"), NumberOfBeds=1, Size=15},Floor="1"},
                new Room{Name="104",Description="Room 104",Details = new RoomDetail{RoomType = (RoomType)RoomTypeService.GetOneByRoomType("Single"), NumberOfBeds=1, Size=15},Floor="1"},
                new Room{Name="201",Description="Room 201",Details = new RoomDetail{RoomType = (RoomType)RoomTypeService.GetOneByRoomType("Single"), NumberOfBeds=1, Size=15},Floor="2",IsInactive=true},
                new Room{Name="202",Description="Room 202",Details = new RoomDetail{RoomType = (RoomType)RoomTypeService.GetOneByRoomType("Double"), NumberOfBeds=2, Size=30},Floor="2"},
                new Room{Name="203",Description="Room 203",Details = new RoomDetail{RoomType = (RoomType)RoomTypeService.GetOneByRoomType("Single"), NumberOfBeds=1, Size=15},Floor="2"},
                new Room{Name="204",Description="Room 204",Details = new RoomDetail{RoomType = (RoomType)RoomTypeService.GetOneByRoomType("Family"), NumberOfBeds=4, Size=30},Floor="2"},
                new Room{Name="301",Description="Room 301",Details = new RoomDetail{RoomType = (RoomType)RoomTypeService.GetOneByRoomType("Family"), NumberOfBeds=5, Size=35},Floor="3"},
                new Room{Name="302",Description="Room 302",Details = new RoomDetail{RoomType = (RoomType)RoomTypeService.GetOneByRoomType("Suite"), NumberOfBeds=2, Size=45},Floor="3"},
            };

            return _rooms;
        }
    }
}
