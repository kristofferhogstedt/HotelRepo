using Hotel.src.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading;

namespace Hotel.src.Persistence
{
    public class DatabaseLair : IDatabaseLair
    {
        private static DatabaseLair _instance;
        private static readonly object _lock = new object(); // Lock for Thread safety
        public static ApplicationDbContext DatabaseContext { get; set; }

        public DatabaseLair()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            DatabaseContext = ApplicationDbContext.GetInstance(options); 
        }

        public static IDatabaseLair GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseLair();
                    }
                }
            }
            return _instance;
        }

        public void SeedAndMigrate()
        {
            DataInitializer.Initialize();
            DatabaseContext.Database.Migrate();
        }
    }
}
