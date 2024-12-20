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
        public IConfigurationBuilder Builder { get; set; } 
        public IConfiguration Config { get; set; }
        public string ConnectionString { get; set; }
        public DbContextOptionsBuilder Options { get; set; }
        private static DatabaseLair _instance;

        public DatabaseLair()
        {
            Builder = new ConfigurationBuilder().AddJsonFile(Settings.AppSettingsFileName, true, true);
            Config = Builder.Build();
            Options = new DbContextOptionsBuilder<ApplicationDbContext>();
            ConnectionString = Config.GetConnectionString("DefaultConnection");
            Options.UseSqlServer(ConnectionString);
        }

        public static DatabaseLair GetInstance()
        {
            if (_instance == null)
                _instance = new DatabaseLair();
            return _instance;
        }
    }
}
