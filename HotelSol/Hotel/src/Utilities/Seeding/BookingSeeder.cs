using Bogus;
using Hotel.Enums;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.Persistence;
using Hotel.src.Utilities.Seeding.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Utilities.Seeding
{
    public class BookingSeeder : ISeedable
    {
        //public static void Seed()
        //{
        //    if (DatabaseLair.DatabaseContext.Bookings.Any())
        //    {
        //        return;   // DB already contains data
        //    }

        //    var _seededModels = BookingSeeder.CreateSeed(10);
        //    foreach (var entity in _seededModels)
        //    {
        //        DatabaseLair.DatabaseContext.Bookings.Add(entity);
        //    }

        //    DatabaseLair.DatabaseContext.SaveChanges();
        //}
        //public static List<Booking> CreateSeed(int num)
        //{
        //    //var _bookings = new List<IBooking>()
        //    //{
        //    //    new Booking{Name="101",Description="Room 101",Type = ERoomType.Single,Floor="1",NumberOfBeds=1,IsActive=true},
        //    //    new Room{Name="102",Description="Room 102",Type = ERoomType.Double,Floor="1",NumberOfBeds=2,IsActive=true},
        //    //    new Room{Name="103",Description="Room 103",Type = ERoomType.Double,Floor="1",NumberOfBeds=2,IsActive=true},
        //    //    new Room{Name="104",Description="Room 104",Type = ERoomType.Single,Floor="1",NumberOfBeds=1,IsActive=true},
        //    //    new Room{Name="105",Description="Room 105",Type = ERoomType.Single,Floor="1",NumberOfBeds=1,IsActive=true},
        //    //    new Room{Name="106",Description="Room 106",Type = ERoomType.Double,Floor="1",NumberOfBeds=2,IsActive=true}
        //    //};

        //    var _bookings = _bookingFaker.Generate(num);
        //    return _bookings;
        //}
    }
}