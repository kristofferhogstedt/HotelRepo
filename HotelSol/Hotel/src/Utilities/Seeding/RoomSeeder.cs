﻿using Hotel.Enums;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.Persistence;
using Hotel.src.Utilities.Seeding.Interfaces;

namespace Hotel.src.Utilities.Seeding
{
    public class RoomSeeder : ISeedable
    {
        public static void Seed(DatabaseLair databaseLair)
        {
            if (databaseLair.DatabaseContext.Rooms.Any())
            {
                return;   // DB already contains data
            }

            var _rooms = CreateSeed();
            foreach (var room in _rooms)
            {
                databaseLair.DatabaseContext.Rooms.Add((Room)room);
            }

            databaseLair.DatabaseContext.SaveChanges();
        }

        /// <summary>
        /// Creates custom seed data (without Bogus NuGet)
        /// </summary>
        /// <returns></returns>
        public static List<IRoom> CreateSeed()
        {
            var _rooms = new List<IRoom>()
            {
                new Room{Name="101",Description="Room 101",RoomType=(new RoomDetails{Type = ERoomType.Single}),Floor="1",NumberOfBeds=1},
                new Room{Name="102",Description="Room 102",RoomType=(new RoomDetails{Type = ERoomType.Double}),Floor="1",NumberOfBeds=2},
                new Room{Name="103",Description="Room 103",RoomType=(new RoomDetails{Type = ERoomType.Double}),Floor="1",NumberOfBeds=2},
                new Room{Name="104",Description="Room 104",RoomType=(new RoomDetails{Type = ERoomType.Single}),Floor="1",NumberOfBeds=1},
                new Room{Name="105",Description="Room 105",RoomType=(new RoomDetails{Type = ERoomType.Single}),Floor="1",NumberOfBeds=1},
                new Room{Name="106",Description="Room 106",RoomType=(new RoomDetails{Type = ERoomType.Double}),Floor="1",NumberOfBeds=2},
                new Room{Name="107",Description="Room 107",RoomType=(new RoomDetails{Type = ERoomType.Double}),Floor="1",NumberOfBeds=2},
                new Room{Name="108",Description="Room 108",RoomType=(new RoomDetails{Type = ERoomType.Single}),Floor="1",NumberOfBeds=1},
                new Room{Name="109",Description="Room 109",RoomType=(new RoomDetails{Type = ERoomType.Single}),Floor="1",NumberOfBeds=1},
                new Room{Name="110",Description="Room 110",RoomType=(new RoomDetails{Type = ERoomType.Double}),Floor="1",NumberOfBeds=2},
                new Room{Name="201",Description="Room 201",RoomType=(new RoomDetails{Type = ERoomType.Single}),Floor="2",NumberOfBeds=1},
                new Room{Name="202",Description="Room 202",RoomType=(new RoomDetails{Type = ERoomType.Double}),Floor="2",NumberOfBeds=2},
                new Room{Name="203",Description="Room 203",RoomType=(new RoomDetails{Type = ERoomType.Double}),Floor="2",NumberOfBeds=2},
                new Room{Name="204",Description="Room 204",RoomType=(new RoomDetails{Type = ERoomType.Single}),Floor="2",NumberOfBeds=1},
                new Room{Name="205",Description="Room 205",RoomType=(new RoomDetails{Type = ERoomType.Single}),Floor="2",NumberOfBeds=1},
                new Room{Name="206",Description="Room 206",RoomType=(new RoomDetails{Type = ERoomType.Family}),Floor="2",NumberOfBeds=4},
                new Room{Name="207",Description="Room 207",RoomType=(new RoomDetails{Type = ERoomType.Family}),Floor="2",NumberOfBeds=4},
                new Room{Name="301",Description="Room 301",RoomType=(new RoomDetails{Type = ERoomType.Suite}),Floor="3",NumberOfBeds=2},
                new Room{Name="302",Description="Room 302",RoomType=(new RoomDetails{Type = ERoomType.Suite}),Floor="3",NumberOfBeds=2},
            };

            return _rooms;
        }
    }
}
