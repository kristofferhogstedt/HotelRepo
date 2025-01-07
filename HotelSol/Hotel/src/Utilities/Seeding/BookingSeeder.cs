using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Services;
using Hotel.src.ModelManagement.Utilities.Calculators;
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
            // Booking(Room, Customer, FromDate, ToDate)
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
                
                //new Booking{CustomerID=1, Room=(Room)RoomService.GetOneByID(1)
                //, CreatedDate=DateTime.Now.AddDays(-10)
                //, FromDate=DateTime.Now.AddDays(10), ToDate=DateTime.Now.AddDays(13)
                //},
                //new Booking{CustomerID=3, Room=(Room)RoomService.GetOneByID(3)
                //, CreatedDate=DateTime.Now.AddDays(-8)
                //, FromDate=DateTime.Now.AddDays(14), ToDate=DateTime.Now.AddDays(17)
                //},
                //new Booking{CustomerID=4, Room=(Room)RoomService.GetOneByID(9)
                //, CreatedDate=DateTime.Now.AddDays(-20)
                //, FromDate=DateTime.Now.AddDays(-4), ToDate=DateTime.Now.AddDays(-1)
                //, IsInactive=true
                //, InactivatedDate=DateTime.Now.AddDays(-1)
                //, UpdatedDate=DateTime.Now.AddDays(-1)},
                //new Booking{CustomerID=5, Room=(Room)RoomService.GetOneByID(7)
                //, CreatedDate=DateTime.Now.AddDays(-5)
                //, FromDate=DateTime.Now.AddDays(5), ToDate=DateTime.Now.AddDays(7)
                //, UpdatedDate=DateTime.Now.AddDays(-1)},
                //new Booking{CustomerID=6, Room=(Room)RoomService.GetOneByID(4)
                //, CreatedDate=DateTime.Now.AddDays(-39)
                //, FromDate=DateTime.Now.AddDays(1), ToDate=DateTime.Now.AddDays(3)},
            };

            return _bookings;
        }
    }
}