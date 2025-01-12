using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;

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
        void Update(IModel modelToUpdate);
        void Delete(IModel modelToDelete);
        void Reactivate(IModel modelToReactivate);
    }
}
