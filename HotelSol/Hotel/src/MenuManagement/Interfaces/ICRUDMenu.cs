﻿using Hotel.src.ModelManagement.Controllers.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Interfaces
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
