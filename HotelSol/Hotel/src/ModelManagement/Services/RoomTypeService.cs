using Hotel.src.ModelManagement.Models.Enums;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.ModelManagement.Utilities.Messagers;
using Hotel.src.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Services
{
    public class RoomTypeService
    {
        public static IRoomType GetOneByRoomType(string searchString, bool getRelatedObjects)
        {
            var _entitylToReturn = (IRoomType)DatabaseLair.DatabaseContext.RoomTypes
                .First(e => e.Name == searchString);

            if (_entitylToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entitylToReturn;
        }
        public static IRoomType GetOneByID(int searchString, bool getRelatedObjects, bool isInactive)
        {
            var _entityToReturn = (IRoomType)DatabaseLair.DatabaseContext.RoomTypes
                .Where(e => e.IsInactive == isInactive)
                .First(e => e.ID == searchString);

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entityToReturn;
        }

        public static IRoomType GetOneByIDSeed(int searchString, bool getRelatedObjects)
        {
            var _entityToReturn = (IRoomType)DatabaseLair.DatabaseContext.RoomTypes
                .First(e => e.ID == searchString);

            if (_entityToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
                return null;
            }

            return _entityToReturn;
        }

        public static List<IRoomType> GetAll(bool getRelatedObjects, bool isInactive)
        {
            List<IRoomType> _listToReturn = null;
            if (DatabaseLair.DatabaseContext.RoomTypes
                .Any(e => e.IsInactive == isInactive))
            {
				_listToReturn = DatabaseLair.DatabaseContext.RoomTypes
				.Where(e => e.IsInactive == isInactive)
				.ToList<IRoomType>();
			}

            if (_listToReturn == null)
            {
                Console.Clear();
                ServiceMessager.DataNotFoundMessage();
            }
            return _listToReturn;
            // Guard clause?
        }
    }
}
