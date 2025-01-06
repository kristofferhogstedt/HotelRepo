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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static IRoomDetails GetOneByID(int searchString)
        {
            var _entityToReturn = (IRoomDetails)DatabaseLair.DatabaseContext.RoomDetails
                .Where(e => e.IsInactive == false)
                .First(m => m.ID == searchString);

            _entityToReturn = GetSubDataRoomType(_entityToReturn); // Get subdata

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
        public static IRoomDetails GetOneByIDSeed(int searchString)
        {
            var _entityToReturn = (IRoomDetails)DatabaseLair.DatabaseContext.RoomDetails
                .First(m => m.ID == searchString);

            _entityToReturn = GetSubDataRoomType(_entityToReturn); // Get subdata

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }

            return _entityToReturn;
        }

        public static IRoomDetails GetOneByRoomID(int searchString)
        {
            var _entityToReturn = (IRoomDetails)DatabaseLair.DatabaseContext.RoomDetails
                .Where(e => e.IsInactive == false)
                .First(m => m.RoomID == searchString);

            _entityToReturn = GetSubDataRoomType(_entityToReturn); // Get subdata

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
        public static IRoomDetails GetOneByRoomIDSeed(int searchString)
        {
            var _entityToReturn = (IRoomDetails)DatabaseLair.DatabaseContext.RoomDetails
                .First(m => m.RoomID == searchString);

            _entityToReturn = GetSubDataRoomType(_entityToReturn); // Get subdata

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }

            return _entityToReturn;
        }

        public static List<IRoomDetails> GetAll()
        {
            var _listToReturn = DatabaseLair.DatabaseContext.RoomDetails
                .Where(e => e.IsInactive == false)
                .ToList<IRoomDetails>();

            _listToReturn = GetSubDataRoomType(_listToReturn); // Get subdata

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
            }
            else
            {
                Create(entityToUpdate);
            }
        }

        public void Delete(IRoomDetails entityToDelete)
        {
            var _entityToDelete = (RoomDetails)entityToDelete;
            _entityToDelete.IsInactive = true;
            _entityToDelete.InactivatedDate = DateTime.Now;
            DatabaseLair.DatabaseContext.RoomDetails.Update(_entityToDelete);
            DatabaseLair.DatabaseContext.SaveChanges();
        }


        // Getters for subdata
        //----------------------------------------------

        // Room type
        public static IRoomDetails GetSubDataRoomType(IRoomDetails entity)
        {
            var _entityToReturn = (IRoomDetails)entity;
            _entityToReturn.RoomType = (RoomType)RoomTypeService.GetOneByID(_entityToReturn.RoomTypeID);
            return _entityToReturn;
        }

        public static List<IRoomDetails> GetSubDataRoomType(List<IRoomDetails> entityList)
        {
            var _listToReturn = new List<IRoomDetails>();
            foreach (IRoomDetails entity in entityList)
            {
                entity.RoomType = (RoomType)RoomTypeService.GetOneByID(entity.RoomTypeID);
                _listToReturn.Add(entity);
            };
            return _listToReturn;
        }

        // Room
        public static IModel GetSubDataRoom(IModel entity)
        {
            var _entityToReturn = (IRoomDetails)entity;
            _entityToReturn.Room = (Room)RoomService.GetOneByID(_entityToReturn.RoomTypeID);
            return _entityToReturn;
        }

        public static List<IRoomDetails> GetSubDataRoom(List<IRoomDetails> entityList)
        {
            var _listToReturn = new List<IRoomDetails>();
            foreach (IRoomDetails entity in entityList)
            {
                entity.Room = (Room)RoomService.GetOneByID(entity.RoomTypeID);
                _listToReturn.Add(entity);
            };
            return _listToReturn;
        }
    }
}
