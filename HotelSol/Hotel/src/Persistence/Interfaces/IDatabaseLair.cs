using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hotel.src.Persistence.Interfaces
{
    public interface IDatabaseLair
    {
        void CreateDbConnection();
        static void SeedAndMigrate() { }
        static void CloseConnection() { }
    }
}