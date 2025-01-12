using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.MenuManagement.Menus.Interfaces
{
    public interface ICRUDMenu
    {
        public static IModelController GetInstance()
        {
            return null;
        }

        void Run(IModel modelToCRUD);
    }
}
