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
        EModelType ModelType { get; set; }
        void Create();
        IModel GetOne();
        void ReadOne();
        void ReadAll();
        void Update();
        void Update(IModel modelToUpdate);
        void Delete();
    }
}
