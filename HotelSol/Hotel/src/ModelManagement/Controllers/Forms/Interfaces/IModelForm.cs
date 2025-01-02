﻿using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers.Forms.Interfaces
{
    public interface IModelForm
    {
        IModel EditForm();
        void DisplaySummary();
    }
}
