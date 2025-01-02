using Hotel.src.Interfaces;
using Hotel.src.MenuManagement.Interfaces;
using Hotel.src.ModelManagement.Controllers;
using Hotel.src.ModelManagement.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.FactoryManagement
{
    internal class ModelFactory
    {
        //private IApp _app;

        public ModelFactory()
        {
            //_app = app;
        }

        public static IModelController GetModelController(IMenu previousMenu)
        {
            return CustomerController.GetInstance(previousMenu) as IModelController;
        }
    }
}

