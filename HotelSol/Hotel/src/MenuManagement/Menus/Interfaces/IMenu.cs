using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Controllers;
using Hotel.src.ModelManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.MenuManagement.Menus.Interfaces
{
    public interface IMenu
    {
        public static IModelController GetInstance()
        {
            return null;
        }

        void Run();
        //void Run(IModel model);
        //void Select();
    }
}
