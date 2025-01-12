using Hotel.src.ModelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.src.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private static readonly object _lock = new object();
        private static ApplicationDbContext _instance;
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomDetails> RoomDetails { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public static ApplicationDbContext GetInstance(DbContextOptionsBuilder<ApplicationDbContext> options)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ApplicationDbContext(options.Options);
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// Used for initial connection to database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(Settings.DatabaseString);
        }

    }
}




