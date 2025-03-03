﻿using Hotel.src.ModelManagement.Models;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Utilities.Checkers;
using Hotel.src.ModelManagement.Utilities.Messagers;
using Hotel.src.Persistence;

namespace Hotel.src.ModelManagement.Services
{
    public class RoomService
    {
        public static void Create(IRoom entityToCreate)
        {
            try
            {
                DatabaseLair.DatabaseContext.Rooms.Add((Room)entityToCreate);
                RoomDetailsService.Create(entityToCreate.Details);

                DatabaseLair.DatabaseContext.SaveChanges();

                Console.WriteLine("Skapande lyckat!");
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static IModel GetOneByID(int searchString, bool getRelatedObjects, bool isInactive)
        {
            var _entityToReturn = (IRoom)DatabaseLair.DatabaseContext.Rooms
                .Where(e => e.IsInactive == isInactive)
                .First(e => e.ID == searchString);

            if (getRelatedObjects)
            {
                _entityToReturn = GetSubData(_entityToReturn); // Get subdata
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
        public static IModel GetOneByIDSeed(int searchString, bool getRelatedObjects)
        {
            var _entityToReturn = (IRoom)DatabaseLair.DatabaseContext.Rooms
                .First(e => e.ID == searchString);

            if (getRelatedObjects)
            {
                _entityToReturn = GetSubData(_entityToReturn); // Get subdata
            }

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }

            return _entityToReturn;
        }

        public static IRoom GetOneByRoomNumber(string searchString, bool getRelatedObjects, bool isInactive)
        {
            var _entityToReturn = (IRoom)DatabaseLair.DatabaseContext.Rooms
                .Where(e => e.IsInactive == isInactive)
                .First(e => e.Name == searchString);

            if (getRelatedObjects)
            {
                _entityToReturn = GetSubData(_entityToReturn); // Get subdata
            }

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }

            return _entityToReturn;
        }

        public static List<IRoom> GetAll(bool getRelatedObjects, bool isInactive)
        {
            List<IRoom> _listToReturn = null;
            if (DatabaseLair.DatabaseContext.Rooms
                .Any(e => e.IsInactive == isInactive))
            {
                _listToReturn = DatabaseLair.DatabaseContext.Rooms
                .Where(e => e.IsInactive == isInactive)
                .ToList<IRoom>();

                if (getRelatedObjects)
                {
                    _listToReturn = GetSubData(_listToReturn);
                }
            }

            if (_listToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }
            return _listToReturn;
        }

        public static void Update(IRoom entityToUpdate)
        {
            var existingEntity = DatabaseLair.DatabaseContext.Rooms
                .FirstOrDefault(c => c.ID == entityToUpdate.ID);
            entityToUpdate.UpdatedDate = DateTime.Now;

            if (existingEntity != null)
            {
                DatabaseLair.DatabaseContext.Entry(existingEntity).CurrentValues.SetValues(entityToUpdate);
                RoomDetailsService.Update(entityToUpdate.Details);

                DatabaseLair.DatabaseContext.SaveChanges();
                Console.WriteLine("Uppdatering lyckad!");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Uppdatering misslyckad... återgår");
                Thread.Sleep(1000);
            }
        }

        public static void Delete(IRoom entityToDelete)
        {
            var existingEntity = DatabaseLair.DatabaseContext.Rooms
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
        public static IRoom GetSubData(IRoom entity)
        {
            var _entityToReturn = entity;
            bool _getRelatedObjects = false;
            // Get corresponding RoomDetails from db
            if (DataElementChecker.CheckRoomDetailsDataExistsByRoomID(_entityToReturn.ID))
            {
                _entityToReturn.Details = (RoomDetails)RoomDetailsService.GetOneByRoomIDSeed(_entityToReturn.ID, _getRelatedObjects);
                _entityToReturn.Details.RoomType = (RoomType)RoomTypeService.GetOneByIDSeed(_entityToReturn.Details.RoomTypeID, _getRelatedObjects);
            }
            else
                ServiceMessager.SubDataNotFoundMessage();
            return _entityToReturn;
        }

        public static List<IRoom> GetSubData(List<IRoom> entityList)
        {
            // Get corresponding RoomDetails from db
            var _listToReturn = new List<IRoom>();
            bool _getRelatedObjects = false;
            foreach (IRoom entity in entityList)
            {
                if (DataElementChecker.CheckRoomDetailsDataExistsByRoomID(entity.ID))
                {
                    entity.Details = (RoomDetails)RoomDetailsService.GetOneByRoomIDSeed(entity.ID, _getRelatedObjects);
                    entity.Details.RoomType = (RoomType)RoomTypeService.GetOneByIDSeed(entity.Details.RoomTypeID, _getRelatedObjects);
                    _listToReturn.Add(entity);
                }
                else
                    ServiceMessager.SubDataNotFoundMessage();

            };
            return _listToReturn;
        }
    }
}
