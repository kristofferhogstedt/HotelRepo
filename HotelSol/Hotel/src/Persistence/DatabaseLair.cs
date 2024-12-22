using Hotel.src.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Persistence
{
    public class DatabaseLair : IDatabaseLair
    {
        //public IConfigurationBuilder Builder { get; set; } 
        //public IConfiguration Config { get; set; }
        //public string ConnectionString { get; set; }
        //public DbContextOptionsBuilder Options { get; set; }
        private static DatabaseLair _instance;
        public ApplicationDbContext DatabaseContext { get; set; }

        public DatabaseLair()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            DatabaseContext = new ApplicationDbContext(options.Options);
        }

        public static DatabaseLair GetInstance()
        {
            if (_instance == null)
                _instance = new DatabaseLair();
            return _instance;
        }
    }
}
