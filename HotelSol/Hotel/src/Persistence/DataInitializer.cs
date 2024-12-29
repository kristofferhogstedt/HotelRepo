using Hotel.Enums;
using Hotel.src.ModelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Persistence
{
    public class DataInitializer
    {
        public static void Initialize(DatabaseLair context)
        {
            context.DatabaseContext.EnsureCreated();

            // Look for any rooms.
            if (context.DatabaseContext.Rooms.Any())
            {
                return;   // DB has been seeded
            }

            var rooms = new List<Room>()
            {
                new Room{Name="101",Description="Room 101",RoomType=ERoomType.Single,Floor="1",NumberOfBeds=1},
                new Room{Name="102",Description="Room 102",RoomType=ERoomType.Double,Floor="1",NumberOfBeds=2},
                new Room{Name="103",Description="Room 103",RoomType=ERoomType.Double,Floor="1",NumberOfBeds=2},
                new Room{Name="104",Description="Room 104",RoomType=ERoomType.Single,Floor="1",NumberOfBeds=1},
                new Room{Name="105",Description="Room 105",RoomType=ERoomType.Single,Floor="1",NumberOfBeds=1},
                new Room{Name="106",Description="Room 106",RoomType=ERoomType.Double,Floor="1",NumberOfBeds=2},
                new Room{Name="107",Description="Room 107",RoomType=ERoomType.Double,Floor="1",NumberOfBeds=2},
                new Room{Name="108",Description="Room 108",RoomType=ERoomType.Single,Floor="1",NumberOfBeds=1},
                new Room{Name="109",Description="Room 109",RoomType=ERoomType.Single,Floor="1",NumberOfBeds=1},
                new Room{Name="110",Description="Room 110",RoomType=ERoomType.Double,Floor="1",NumberOfBeds=2},
                new Room{Name="201",Description="Room 201",RoomType=ERoomType.Single,Floor="2",NumberOfBeds=1},
                new Room{Name="202",Description="Room 202",RoomType=ERoomType.Double,Floor="2",NumberOfBeds=2},
                new Room{Name="203",Description="Room 203",RoomType=ERoomType.Double,Floor="2",NumberOfBeds=2},
                new Room{Name="204",Description="Room 204",RoomType=ERoomType.Single,Floor="2",NumberOfBeds=1},
                new Room{Name="205",Description="Room 205",RoomType=ERoomType.Single,Floor="2",NumberOfBeds=1},
                new Room{Name="206",Description="Room 206",RoomType=ERoomType.Family,Floor="2",NumberOfBeds=4},
                new Room{Name="207",Description="Room 207",RoomType=ERoomType.Family,Floor="2",NumberOfBeds=4},
                new Room{Name="301",Description="Room 301",RoomType=ERoomType.Suite,Floor="3",NumberOfBeds=2},
                new Room{Name="302",Description="Room 302",RoomType=ERoomType.Suite,Floor="3",NumberOfBeds=2},
            };
        }
    }
}
