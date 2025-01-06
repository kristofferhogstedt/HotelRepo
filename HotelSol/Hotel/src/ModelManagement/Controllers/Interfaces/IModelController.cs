using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Controllers.Interfaces
{
    public interface IModelController
    {
        EModelType ModelTypeEnum { get; set; }
        void Create();
        void Create(IModel entityToCreate);
        IModel BrowseOne(bool isInactive);
        void ManageOne(bool isInactive);
        void ReadAll(bool isInactive);
        //void Update();
        void Update(IModel modelToUpdate);
        void Delete(IModel modelToDelete);
    }
}
