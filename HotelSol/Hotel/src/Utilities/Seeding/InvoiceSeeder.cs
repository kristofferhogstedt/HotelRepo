using Hotel.src.ModelManagement.Models;
using Hotel.src.Persistence;
using Hotel.src.Utilities.Seeding.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Utilities.Seeding
{
    public class InvoiceSeeder : ISeedable
    {
        public static void Seed()
        {
            if (DatabaseLair.DatabaseContext.Invoices.Any())
            {
                return;   // DB already contains data
            }
            var _seededModels = InvoiceSeeder.CreateSeed(4);
            foreach (var entity in _seededModels)
            {
                DatabaseLair.DatabaseContext.Invoices.Add(entity);
            }
            DatabaseLair.DatabaseContext.SaveChanges();
        }

        public static List<Invoice> CreateSeed(int num)
        {
            var _bookings = new List<Invoice>()
            {
                new Invoice{BookingID=1, Amount=1000
                , CreatedDate=DateTime.Now.AddDays(-10)
                , IsInactive=true, InactivatedDate=DateTime.Now.AddDays(-8)
                , DueDate=DateTime.Now.AddDays(20)
                , IsPaid=true, PaidDate=DateTime.Now.AddDays(-8)},
                new Invoice{BookingID=2, Amount=1000
                , CreatedDate=DateTime.Now.AddDays(-8)
                , DueDate=DateTime.Now.AddDays(24)
                , IsPaid=false},
                new Invoice{BookingID=3, Amount=1400
                , CreatedDate=DateTime.Now.AddDays(-20)
                , IsInactive=true, InactivatedDate=DateTime.Now.AddDays(-20)
                , DueDate=DateTime.Now.AddDays(6)
                , IsPaid=true, PaidDate=DateTime.Now.AddDays(-20)},
                new Invoice{BookingID=4, Amount=1000
                , CreatedDate=DateTime.Now.AddDays(-5)
                , DueDate=DateTime.Now.AddDays(15)
                , IsPaid=false}
            };

            return _bookings;
        }
    }
}
