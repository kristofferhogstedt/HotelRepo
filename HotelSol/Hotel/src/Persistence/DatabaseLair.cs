using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Persistence
{
    public class DatabaseLair
    {
        public ApplicationDbContext GetDbContext()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json",
                true, true);
            var config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var options = new DbContextOptionsBuilder<StudentContext>();
            options.UseSqlServer(connectionString);

            return new StudentContext(options.Options);
        }
    }
}
