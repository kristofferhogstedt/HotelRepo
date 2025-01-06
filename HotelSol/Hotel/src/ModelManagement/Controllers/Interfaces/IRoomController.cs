using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers.Interfaces
{
    public interface IRoomController : IModelController
    {
        public void UpdateBeds(IModel entityToUpdate);

    }
}
