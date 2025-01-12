using Hotel.src.ModelManagement.Models.Interfaces;

namespace Hotel.src.ModelManagement.Controllers.Interfaces
{
    public interface IRoomController : IModelController
    {
        public void UpdateBeds(IModel entityToUpdate);
    }
}
