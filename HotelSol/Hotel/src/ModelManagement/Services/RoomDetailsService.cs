using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Utilities.Checkers;
using Hotel.src.ModelManagement.Utilities.Messagers;
using Hotel.src.Persistence;

namespace Hotel.src.ModelManagement.Services
{
    internal class RoomDetailsService
    {
        public static void Create(IRoomDetails entityToCreate)
        {
            try
            {
                DatabaseLair.DatabaseContext.RoomDetails.Add((RoomDetails)entityToCreate);
                DatabaseLair.DatabaseContext.SaveChanges();
                Console.WriteLine("Skapande lyckat!");
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static IRoomDetails GetOneByID(int searchString, bool getRelatedObjects, bool isInactive)
        {
            var _entityToReturn = (IRoomDetails)DatabaseLair.DatabaseContext.RoomDetails
                .First(m => m.ID == searchString);

            if (getRelatedObjects)
            {
                _entityToReturn = GetSubDataRoomType(_entityToReturn); // Get subdata
            }

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
        public static IRoomDetails GetOneByIDSeed(int searchString, bool getRelatedObjects)
        {
            var _entityToReturn = (IRoomDetails)DatabaseLair.DatabaseContext.RoomDetails
                .First(m => m.ID == searchString);

            if (getRelatedObjects)
            {
                _entityToReturn = GetSubDataRoomType(_entityToReturn); // Get subdata
            }

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }

            return _entityToReturn;
        }

        public static IRoomDetails GetOneByRoomID(int searchString, bool getRelatedObjects, bool isInactive)
        {
            var _entityToReturn = (IRoomDetails)DatabaseLair.DatabaseContext.RoomDetails
                .First(m => m.RoomID == searchString);

            if (getRelatedObjects)
            {
                _entityToReturn = GetSubDataRoomType(_entityToReturn); // Get subdata
            }

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
        public static IRoomDetails GetOneByRoomIDSeed(int searchString, bool getRelatedObjects)
        {
            var _entityToReturn = (IRoomDetails)DatabaseLair.DatabaseContext.RoomDetails
                .First(m => m.RoomID == searchString);

            if (getRelatedObjects)
            {
                _entityToReturn = GetSubDataRoomType(_entityToReturn); // Get subdata
            }

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }

            return _entityToReturn;
        }

        public static List<IRoomDetails> GetAll(bool getRelatedObjects, bool isInactive)
        {
            List<IRoomDetails> _listToReturn = null;
            if (DatabaseLair.DatabaseContext.RoomDetails.Any())
            {
                DatabaseLair.DatabaseContext.RoomDetails
                .ToList<IRoomDetails>();

                if (getRelatedObjects)
                {
                    _listToReturn = GetSubDataRoomType(_listToReturn); // Get subdata
                }
            }
            else
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }
            return _listToReturn;
            // Guard clause?
        }

        public static void Update(IRoomDetails entityToUpdate)
        {
            var existingEntity = DatabaseLair.DatabaseContext.RoomDetails
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
                Console.WriteLine("Uppdatering misslyckad... Återgår");
                Thread.Sleep(1000);
            }
        }

        public static void Delete(IRoomDetails entityToDelete)
        {
            var existingEntity = DatabaseLair.DatabaseContext.RoomDetails
                .FirstOrDefault(c => c.ID == entityToDelete.ID);
            entityToDelete.IsInactive = true;
            entityToDelete.InactivatedDate = DateTime.Now;

            if (existingEntity != null)
            {
                DatabaseLair.DatabaseContext.Entry(existingEntity).CurrentValues.SetValues(entityToDelete);

                DatabaseLair.DatabaseContext.SaveChanges();
                Console.WriteLine("Inaktivering lyckad!");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Inaktivering misslyckad, återgår");
                Thread.Sleep(1000);
                return;
            }
        }


        // Getters for subdata
        //----------------------------------------------

        // Room type
        public static IRoomDetails GetSubDataRoomType(IRoomDetails entity)
        {
            var _entityToReturn = (IRoomDetails)entity;
            bool _getRelatedObjects = false;
            if (DataElementChecker.CheckRoomTypeDataExists(_entityToReturn.RoomTypeID))
                _entityToReturn.RoomType = (RoomType)RoomTypeService.GetOneByIDSeed(_entityToReturn.RoomTypeID, _getRelatedObjects);
            else
                ServiceMessager.SubDataNotFoundMessage();

            return _entityToReturn;
        }

        public static List<IRoomDetails> GetSubDataRoomType(List<IRoomDetails> entityList)
        {
            var _listToReturn = new List<IRoomDetails>();
            bool _getRelatedObjects = false;
            foreach (IRoomDetails entity in entityList)
            {
                if (DataElementChecker.CheckRoomTypeDataExists(entity.RoomTypeID))
                {
                    entity.RoomType = (RoomType)RoomTypeService.GetOneByIDSeed(entity.RoomTypeID, _getRelatedObjects);
                    _listToReturn.Add(entity);
                }
                else
                    ServiceMessager.SubDataNotFoundMessage();
            };
            return _listToReturn;
        }


        // Room
        public static IModel GetSubDataRoom(IModel entity)
        {
            var _entityToReturn = (IRoomDetails)entity;
            bool _getRelatedObjects = false;
            if (DataElementChecker.CheckRoomDataExists(_entityToReturn.RoomID))
                _entityToReturn.Room = (Room)RoomService.GetOneByIDSeed(_entityToReturn.RoomID, _getRelatedObjects);
            else
                ServiceMessager.SubDataNotFoundMessage();

            return _entityToReturn;
        }

        public static List<IRoomDetails> GetSubDataRoom(List<IRoomDetails> entityList)
        {
            var _listToReturn = new List<IRoomDetails>();
            bool _getRelatedObjects = false;
            foreach (IRoomDetails entity in entityList)
            {
                if (DataElementChecker.CheckRoomDataExists(entity.RoomID))
                {
                    entity.Room = (Room)RoomService.GetOneByIDSeed(entity.RoomID, _getRelatedObjects);
                    _listToReturn.Add(entity);
                }
                else
                    ServiceMessager.SubDataNotFoundMessage();
            };
            return _listToReturn;
        }
    }
}
