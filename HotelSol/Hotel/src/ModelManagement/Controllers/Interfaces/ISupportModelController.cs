using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers.Interfaces
{
    public interface ISupportModelController
    {
        ISupportModel Create();
        void Update();
        void Delete();

    }
}
