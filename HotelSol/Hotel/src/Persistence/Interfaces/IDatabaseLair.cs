using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hotel.src.Persistence.Interfaces
{
    public interface IDatabaseLair
    {
        //ApplicationDbContext CreateDbConnection();
        void SeedDatabase() { }
        static void CloseDbConnection() { }
    }
}