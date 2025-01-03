using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.ModelManagement.Services.Interfaces
{
    public interface ICustomerService
    {
        void Create(ICustomer customer);
        ICustomer ReadOne();
        List<ICustomer> ReadAll();
        void Update(ICustomer customer);
        string GetFullName();
    }
}
