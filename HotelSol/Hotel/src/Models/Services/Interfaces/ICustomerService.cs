using Hotel.src.Models.Interfaces;

namespace Hotel.src.Models.Services.Interfaces
{
    public interface ICustomerService
    {
        void Create();
        ICustomer ReadOne();
        List<ICustomer> ReadAll();
        void Update();
        string GetFullName();
    }
}
