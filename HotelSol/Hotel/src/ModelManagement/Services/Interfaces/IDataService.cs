using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.ModelManagement.Services.Interfaces
{
    public interface IDataService<T>
    {
        void Create(T model);
        T ReadOne();
        List<T> ReadAll();
        void Update(T model);
    }
}
