using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.Utilities.Seeding.Interfaces
{
    public interface ISeedable
    {
        static virtual void Seed()
        {
        }
        public virtual static List<IModel> CreateSeed(int amount)
        {
            return null;
        }
    }
}
