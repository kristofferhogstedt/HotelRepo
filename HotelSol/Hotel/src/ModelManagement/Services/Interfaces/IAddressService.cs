using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.ModelManagement.Services.Interfaces
{
    public interface IAddressService
    {
        void Create(IAddress address);
        IAddress ReadOne();
        List<IAddress> ReadAll();
        void Update(IAddress address);
    }
}
