using Hotel.src.MenuManagement.Menus.Interfaces;

namespace Hotel.src.FactoryManagement.Interfaces
{
    public interface IInstantiable
    {
        IMenu PreviousMenu { get; set; }
    }
}
