using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Services.Interfaces;
using Hotel.src.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.src.ModelManagement.Utilities.Messagers;

namespace Hotel.src.ModelManagement.Services
{
    internal class RoomDetailsService : IRoomService
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
                .Where(e => e.IsInactive == isInactive)
                .First(m => m.ID == searchString);

            _entityToReturn = GetSubDataRoomType(_entityToReturn, isInactive); // Get subdata

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

            _entityToReturn = GetSubDataRoomTypeSeed(_entityToReturn); // Get subdata

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
                .Where(e => e.IsInactive == isInactive)
                .First(m => m.RoomID == searchString);

            _entityToReturn = GetSubDataRoomType(_entityToReturn, isInactive); // Get subdata

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

            _entityToReturn = GetSubDataRoomTypeSeed(_entityToReturn); // Get subdata

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }

            return _entityToReturn;
        }

        public static List<IRoomDetails> GetAll(bool getRelatedObjects, bool isInactive)
        {
            var _listToReturn = DatabaseLair.DatabaseContext.RoomDetails
                .Where(e => e.IsInactive == isInactive)
                .ToList<IRoomDetails>();

            _listToReturn = GetSubDataRoomTypeSeed(_listToReturn); // Get subdata

            if (_listToReturn == null)
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
        public static IRoomDetails GetSubDataRoomType(IRoomDetails entity, bool isInactive)
        {
            var _entityToReturn = (IRoomDetails)entity;
            bool _getRelatedObjects = false;
            _entityToReturn.RoomType = (RoomType)RoomTypeService.GetOneByID(_entityToReturn.RoomTypeID, _getRelatedObjects, isInactive);
            return _entityToReturn;
        }

        public static List<IRoomDetails> GetSubDataRoomType(List<IRoomDetails> entityList, bool isInactive)
        {
            var _listToReturn = new List<IRoomDetails>();
            bool _getRelatedObjects = false;
            foreach (IRoomDetails entity in entityList)
            {
                entity.RoomType = (RoomType)RoomTypeService.GetOneByID(entity.RoomTypeID, _getRelatedObjects, isInactive);
                _listToReturn.Add(entity);
            };
            return _listToReturn;
        }
        public static IRoomDetails GetSubDataRoomTypeSeed(IRoomDetails entity)
        {
            var _entityToReturn = (IRoomDetails)entity;
            bool _getRelatedObjects = false;
            _entityToReturn.RoomType = (RoomType)RoomTypeService.GetOneByIDSeed(_entityToReturn.RoomTypeID, _getRelatedObjects);
            return _entityToReturn;
        }

        public static List<IRoomDetails> GetSubDataRoomTypeSeed(List<IRoomDetails> entityList)
        {
            var _listToReturn = new List<IRoomDetails>();
            bool _getRelatedObjects = false;
            foreach (IRoomDetails entity in entityList)
            {
                entity.RoomType = (RoomType)RoomTypeService.GetOneByIDSeed(entity.RoomTypeID, _getRelatedObjects);
                _listToReturn.Add(entity);
            };
            return _listToReturn;
        }

        // Room
        public static IModel GetSubDataRoom(IModel entity, bool isInactive)
        {
            var _entityToReturn = (IRoomDetails)entity;
            bool _getRelatedObjects = false;
            _entityToReturn.Room = (Room)RoomService.GetOneByID(_entityToReturn.RoomTypeID, _getRelatedObjects, isInactive);
            return _entityToReturn;
        }

        public static List<IRoomDetails> GetSubDataRoom(List<IRoomDetails> entityList, bool isInactive)
        {
            var _listToReturn = new List<IRoomDetails>();
            bool _getRelatedObjects = false;
            foreach (IRoomDetails entity in entityList)
            {
                entity.Room = (Room)RoomService.GetOneByID(entity.RoomTypeID, _getRelatedObjects, isInactive);
                _listToReturn.Add(entity);
            };
            return _listToReturn;
        }

        //-----------------
        //  For seed
        public static IModel GetSubDataRoomSeed(IModel entity)
        {
            var _entityToReturn = (IRoomDetails)entity;
            bool _getRelatedObjects = false;
            _entityToReturn.Room = (Room)RoomService.GetOneByIDSeed(_entityToReturn.RoomTypeID, _getRelatedObjects);
            return _entityToReturn;
        }
        public static List<IRoomDetails> GetSubDataRoomSeed(List<IRoomDetails> entityList)
        {
            var _listToReturn = new List<IRoomDetails>();
            bool _getRelatedObjects = false;
            foreach (IRoomDetails entity in entityList)
            {
                entity.Room = (Room)RoomService.GetOneByIDSeed(entity.RoomTypeID, _getRelatedObjects);
                _listToReturn.Add(entity);
            };
            return _listToReturn;
        }
    }
}
