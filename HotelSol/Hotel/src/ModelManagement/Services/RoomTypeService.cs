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
        public static IRoomType GetOneByRoomType(string searchString)
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
        public static IRoomType GetOneByID(int searchString)
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

        public static List<IRoomType> GetAll()
        {
            var _listToReturn = DatabaseLair.DatabaseContext.RoomTypes
                .ToList<IRoomType>();

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
