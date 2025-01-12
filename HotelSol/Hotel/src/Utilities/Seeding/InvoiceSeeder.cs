using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services;
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
            bool _getRelatedObjects = false; // Seeders should not get related data
            var _bookings = new List<Invoice>()
            {
                new Invoice((Booking)BookingService.GetOneByIDSeed(1, _getRelatedObjects)) 
                {CreatedDate=DateTime.Now.AddDays(-10), IsInactive=true, InactivatedDate=DateTime.Now.AddDays(-8)
                , DueDate=DateTime.Now.AddDays(20), Amount=800 , IsPaid=true, PaidDate=DateTime.Now.AddDays(-8)},

                new Invoice((Booking)BookingService.GetOneByIDSeed(2, _getRelatedObjects))
                {CreatedDate=DateTime.Now.AddDays(-8), Amount=800, DueDate=DateTime.Now.AddDays(24)
                , IsPaid=false},

                new Invoice((Booking)BookingService.GetOneByIDSeed(3, _getRelatedObjects))
                {CreatedDate=DateTime.Now.AddDays(-20), IsInactive=true, InactivatedDate=DateTime.Now.AddDays(-20)
                , DueDate=DateTime.Now.AddDays(6), Amount=800, IsPaid=true, PaidDate=DateTime.Now.AddDays(-20)},

                new Invoice((Booking)BookingService.GetOneByIDSeed(4, _getRelatedObjects))
                {CreatedDate=DateTime.Now.AddDays(-5)
                , DueDate=DateTime.Now.AddDays(15), Amount=800, IsPaid=false},

                new Invoice((Booking)BookingService.GetOneByIDSeed(5, _getRelatedObjects))
                {CreatedDate=DateTime.Now.AddDays(-39), IsInactive=true, InactivatedDate=DateTime.Now.AddDays(-39)
                , DueDate=DateTime.Now.AddDays(-9), Amount=800, IsPaid=false
                , UpdatedDate=DateTime.Now.AddDays(-9)}
            };

            return _bookings;
        }
    }
}
