using HotelLibrary.Models.Interfaces;
using HotelLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Persistence
{
    class ApplicationDbContext : DbContext
    {
        private readonly string _databaseString = "MyDb";

        public List<ICustomer> Customers { get; set; }
        public IRoom Rooms { get; set; }
        public IInvoice Invoices { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(_databaseString);
        }
    }
}




