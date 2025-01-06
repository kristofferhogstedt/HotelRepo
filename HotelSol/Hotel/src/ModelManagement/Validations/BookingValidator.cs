using Hotel.src.MenuManagement.Menus.Interfaces;
using Hotel.src.ModelManagement.Models.Interfaces;
using Hotel.src.Utilities.UserInputManagement;
using HotelLibrary.Utilities.UserInputManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.ModelManagement.Validations
{
    public class BookingValidator
    {
        public static DateTime ValidateFromDate(bool isAnEdit, IMenu previousMenu)
        {
            var _dateToReturn = UserInputHandlerDateTime.UserInputDateTime(previousMenu);
            
            if (isAnEdit && _dateToReturn == DateTime.MinValue)
                return DateTime.MinValue;
            else
                return _dateToReturn;
        }
        public static DateTime ValidateToDate(bool isAnEdit, IMenu previousMenu)
        {
            var _dateToReturn = UserInputHandlerDateTime.UserInputDateTime(previousMenu);

            if (isAnEdit && _dateToReturn == DateTime.MinValue)
                return DateTime.MinValue;
            else
                return _dateToReturn;
        }

    }
}
