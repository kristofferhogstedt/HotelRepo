using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Menus.Interfaces
{
    public interface IControllable
    {
        EModelType ModelType { get; set; }
        IModelController ModelController { get; set; }
    }
}
