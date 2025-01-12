using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hotel.src.Persistence.Interfaces
{
    public interface IDatabaseLair
    {
        void SeedDatabase() { }
        static void CloseDbConnection() { }
    }
}