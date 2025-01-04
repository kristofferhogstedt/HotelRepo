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
            var _bookings = new List<Booking>()
            {
                new Booking{CustomerID=1, Room=(Room)RoomService.GetOneByID(1)
                , CreatedDate=DateTime.Now.AddDays(-10)
                , FromDate=DateTime.Now.AddDays(10), ToDate=DateTime.Now.AddDays(13)
                },
                new Booking{CustomerID=3, Room=(Room)RoomService.GetOneByID(3)
                , CreatedDate=DateTime.Now.AddDays(-8)
                , FromDate=DateTime.Now.AddDays(14), ToDate=DateTime.Now.AddDays(17)
                },
                new Booking{CustomerID=4, Room=(Room)RoomService.GetOneByID(9)
                , CreatedDate=DateTime.Now.AddDays(-20)
                , FromDate=DateTime.Now.AddDays(-4), ToDate=DateTime.Now.AddDays(-1)
                , IsInactive=true
                , InactivatedDate=DateTime.Now.AddDays(-1)
                , UpdatedDate=DateTime.Now.AddDays(-1)},
                new Booking{CustomerID=5, Room=(Room)RoomService.GetOneByID(7)
                , CreatedDate=DateTime.Now.AddDays(-5)
                , FromDate=DateTime.Now.AddDays(5), ToDate=DateTime.Now.AddDays(7)
                , UpdatedDate=DateTime.Now.AddDays(-1)},
            };

            return _bookings;

            //Customer CustomerID { get; set; }
            //Room RoomID { get; set; }
            //DateTime FromDate { get; set; }
            //DateTime ToDate { get; set; }
            //bool IsActive { get; set; }
            //DateTime CreatedDate { get; set; }
            //DateTime? UpdatedDate { get; set; }
            //DateTime? InactivatedDate { get; set; }

        }
    }
}