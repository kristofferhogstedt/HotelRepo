using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Services.Interfaces;
using Hotel.src.ModelManagement.Utilities.Messagers;
using Hotel.src.Persistence;
using Spectre.Console;

namespace Hotel.src.ModelManagement.Services
{
    public class RoomService : IRoomService
    {
        public static void Create(IRoom entityToCreate)
        {
            try
            {
                DatabaseLair.DatabaseContext.Rooms.Add((Room)entityToCreate);
                DatabaseLair.DatabaseContext.SaveChanges();

                // Meddelande om lyckad registrering
                Console.WriteLine("Skapande lyckat!");
                Thread.Sleep(1000);
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

        public static IModel GetOneByID(int searchString, bool isInactive)
        {
            var _entityToReturn = (IRoom)DatabaseLair.DatabaseContext.Rooms
                .Where(e => e.IsInactive == isInactive)
                .First(e => e.ID == searchString);

            _entityToReturn = GetSubData(_entityToReturn, isInactive); // Get subdata

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }

            return _entityToReturn;
        }
        /// <summary>
        /// For seeder functionality to not care about IsInactive
        /// </summary>
        /// <param name="searchID"></param>
        /// <returns></returns>
        public static IModel GetOneByIDSeed(int searchString)
        {
            var _entityToReturn = (IRoom)DatabaseLair.DatabaseContext.Rooms
                .First(e => e.ID == searchString);

            _entityToReturn = GetSubDataSeed(_entityToReturn); // Get subdata

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }

            return _entityToReturn;
        }

        public static IRoom GetOneByRoomNumber(string searchString, bool isInactive)
        {
            var _entityToReturn = (IRoom)DatabaseLair.DatabaseContext.Rooms
                .Where(e => e.IsInactive == isInactive)
                .First(e => e.Name == searchString);

            _entityToReturn = GetSubData(_entityToReturn, isInactive); // Get subdata

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }

            return _entityToReturn;
        }

        public static List<IRoom> GetAll(bool isInactive)
        {
            var _listOfRooms = DatabaseLair.DatabaseContext.Rooms
                .Where(e => e.IsInactive == isInactive)
                .ToList<IRoom>();

            var _listToReturn = GetSubData(_listOfRooms, isInactive);

            if (_listToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }
            return _listToReturn;
            // Guard clause?
        }

        public static void Update(IRoom entityToUpdate)
        {
            var existingEntity = DatabaseLair.DatabaseContext.Rooms
                .FirstOrDefault(c => c.ID == entityToUpdate.ID);
            entityToUpdate.UpdatedDate = DateTime.Now;

            if (existingEntity != null)
            {
                DatabaseLair.DatabaseContext.Entry(existingEntity).CurrentValues.SetValues(entityToUpdate);

                DatabaseLair.DatabaseContext.SaveChanges();
                Console.WriteLine("Uppdatering lyckad!");
                Thread.Sleep(1000);
            }
            else
            {
                Create(entityToUpdate);
            }

        }

        public void Delete(IRoom entityToDelete)
        {
            var _entityToDelete = (Room)entityToDelete;
            _entityToDelete.IsInactive = true;
            _entityToDelete.InactivatedDate = DateTime.Now;
            DatabaseLair.DatabaseContext.Rooms.Update(_entityToDelete);
            DatabaseLair.DatabaseContext.SaveChanges();
        }


        // Getters for subdata
        //----------------------------------------------
        public static IRoom GetSubData(IRoom entity, bool isInactive)
        {
            var _entityToReturn = entity;
            // Get corresponding RoomDetails from db
            _entityToReturn.Details = (RoomDetails)RoomDetailsService.GetOneByRoomID(_entityToReturn.ID, isInactive);
            return _entityToReturn;
        }
        public static IRoom GetSubDataSeed(IRoom entity)
        {
            var _entityToReturn = entity;
            // Get corresponding RoomDetails from db
            _entityToReturn.Details = (RoomDetails)RoomDetailsService.GetOneByRoomIDSeed(_entityToReturn.ID);
            return _entityToReturn;
        }

        public static List<IRoom> GetSubData(List<IRoom> entityList, bool isInactive)
        {
            // Get corresponding RoomDetails from db
            var _listToReturn = new List<IRoom>();
            foreach (IRoom room in entityList)
            {
                room.Details = (RoomDetails)RoomDetailsService.GetOneByRoomID(room.ID, isInactive);
                _listToReturn.Add(room);
            };
            return _listToReturn;
        }
    }
}
