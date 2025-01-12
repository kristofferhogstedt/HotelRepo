using Hotel.src.ModelManagement.Controllers.Interfaces;

namespace Hotel.src.MenuManagement.Menus.Interfaces
{
    public interface IMenu
    {
        public static IModelController GetInstance()
        {
            return null;
        }

        void Run();
    }
}
