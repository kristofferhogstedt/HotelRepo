using Hotel.src.ModelManagement.Interfaces;

namespace Hotel.src.ModelManagement.Services.Interfaces
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
