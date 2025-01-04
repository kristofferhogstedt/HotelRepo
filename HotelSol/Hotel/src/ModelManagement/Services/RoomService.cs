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

        public static IRoom GetOneByID(int searchID)
        {
            var _modelToReturn = DatabaseLair.DatabaseContext.Rooms
                .Where(m => m.IsActive == true)
                .First(m => m.ID == searchID);

            if (_modelToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _modelToReturn;
        }

        public static List<IRoom> GetAll()
        {
            var _listToReturn = DatabaseLair.DatabaseContext.Rooms
                .Where(m => m.IsActive == true)
                .ToList<IRoom>();

            if (_listToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return _listToReturn;
            }
            return _listToReturn;
            // Guard clause?
        }

        public static void Update(IRoom modelToUpdate)
        {
            DatabaseLair.DatabaseContext.Rooms.Update((Room)modelToUpdate);
            DatabaseLair.DatabaseContext.SaveChanges();
        }

        public void Delete(IRoom modelToDelete)
        {
            var _modelToDelete = (Room)modelToDelete;
            _modelToDelete.IsActive = false;
            _modelToDelete.InactivatedDate = DateTime.Now;
            DatabaseLair.DatabaseContext.Rooms.Update(_modelToDelete);
            DatabaseLair.DatabaseContext.SaveChanges();
        }
    }
}
