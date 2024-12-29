using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.Utilities.Seeding.Interfaces
{
    public interface ISeedable
    {
        static virtual void Seed(DatabaseLair databaseLair)
        {
        }
        public virtual static List<ICustomer> CreateSeed(int num)
        {
            return null;
        }
    }
}
