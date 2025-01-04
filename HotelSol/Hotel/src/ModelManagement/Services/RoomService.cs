using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services.Interfaces;
using Hotel.src.ModelManagement.Utilities.Messagers;
using Hotel.src.Persistence;

namespace Hotel.src.ModelManagement.Services
{
    public class RoomService : IRoomService
    {
        public static void Create(IRoom modelToCreate)
        {
            try
            {
                DatabaseLair.DatabaseContext.Rooms.Add((Room)modelToCreate);
                DatabaseLair.DatabaseContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// For fetching one customer
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        /// 
        //public static IRoom GetOne(string searchString)
        //{
        //    var _modelToReturn = DatabaseLair.DatabaseContext.Rooms
        //        .Where(m => m.IsActive == true)
        //        .First(m => m.FirstName.Contains(searchString)
        //        || m.LastName.Contains(searchString));

        //    if (_modelToReturn == null)
        //    {
        //        Console.Clear();
        //        DataNotFoundMessage();
        //        return null;
        //    }

        //    return _modelToReturn;
        //}

        public static IModel GetOneByID(int searchString)
        {
            var _entityToReturn = DatabaseLair.DatabaseContext.Rooms
                .Where(m => m.IsInactive == false)
                .First(m => m.ID == searchString);

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }

            return _entityToReturn;
        }

        public static IModel GetOneByRoomNumber(string searchString)
        {
            var _entityToReturn = DatabaseLair.DatabaseContext.Rooms
                .Where(m => m.IsInactive == false)
                .First(m => m.Name == searchString);

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }

            return _entityToReturn;
        }

        public static List<IRoom> GetAll()
        {
            var _listToReturn = DatabaseLair.DatabaseContext.Rooms
                .Where(m => m.IsInactive == false)
                .ToList<IRoom>();

            if (_listToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }
            return (IRoom)_listToReturn;
            // Guard clause?
        }

        public static void Update(IRoom entityToUpdate)
        {
            DatabaseLair.DatabaseContext.Rooms.Update((Room)entityToUpdate);
            DatabaseLair.DatabaseContext.SaveChanges();
        }

        public void Delete(IRoom entityToDelete)
        {
            var _entityToDelete = (Room)entityToDelete;
            _entityToDelete.IsInactive = true;
            _entityToDelete.InactivatedDate = DateTime.Now;
            DatabaseLair.DatabaseContext.Rooms.Update(_entityToDelete);
            DatabaseLair.DatabaseContext.SaveChanges();
        }
    }
}
