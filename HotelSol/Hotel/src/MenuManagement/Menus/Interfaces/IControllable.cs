using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;

namespace Hotel.src.MenuManagement.Menus.Interfaces
{
    public interface IControllable
    {
        EModelType ModelType { get; set; }
        IModelController ModelController { get; set; }
    }
}
