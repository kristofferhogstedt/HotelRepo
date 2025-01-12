using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Services;
using Hotel.src.Persistence;
using Hotel.src.Utilities.Seeding.Interfaces;

namespace Hotel.src.Utilities.Seeding
{
    public class BookingSeeder : ISeedable
    {
        public static void Seed()
        {
            if (DatabaseLair.DatabaseContext.Bookings.Any())
            {
                return;   // DB already contains data
            }

            var _seededModels = BookingSeeder.CreateSeed();
            foreach (var entity in _seededModels)
            {
                DatabaseLair.DatabaseContext.Bookings.Add(entity);
            }

            DatabaseLair.DatabaseContext.SaveChanges();
        }
        public static List<Booking> CreateSeed()
        {
            bool _getRelatedObjects = false; // Seeders should not get related objects
            var _bookings = new List<Booking>()
            {
                new Booking((Room)RoomService.GetOneByIDSeed(1, _getRelatedObjects), (Customer)CustomerService.GetOneByIDSeed(1, _getRelatedObjects), DateTime.Now.AddDays(10), DateTime.Now.AddDays(13)),

                new Booking((Room)RoomService.GetOneByIDSeed(3, _getRelatedObjects), (Customer)CustomerService.GetOneByIDSeed(2, _getRelatedObjects), DateTime.Now.AddDays(14), DateTime.Now.AddDays(17)),

                new Booking((Room)RoomService.GetOneByIDSeed(9, _getRelatedObjects), (Customer)CustomerService.GetOneByIDSeed(4, _getRelatedObjects), DateTime.Now.AddDays(-4), DateTime.Now.AddDays(-1))
                { IsInactive=true
                , InactivatedDate=DateTime.Now.AddDays(-1)
                , UpdatedDate=DateTime.Now.AddDays(-1)},

                new Booking((Room)RoomService.GetOneByIDSeed(7, _getRelatedObjects), (Customer)CustomerService.GetOneByIDSeed(5, _getRelatedObjects), DateTime.Now.AddDays(5), DateTime.Now.AddDays(7))
                { UpdatedDate=DateTime.Now.AddDays(-1) },

                new Booking((Room)RoomService.GetOneByIDSeed(4, _getRelatedObjects), (Customer)CustomerService.GetOneByIDSeed(6, _getRelatedObjects), DateTime.Now.AddDays(1), DateTime.Now.AddDays(3))
                { CreatedDate=DateTime.Now.AddDays(-39)
                , IsInactive=true, InactivatedDate=DateTime.Now.AddDays(-9)
                , UpdatedDate=DateTime.Now.AddDays(-9) },
            };

            return _bookings;
        }
    }
}