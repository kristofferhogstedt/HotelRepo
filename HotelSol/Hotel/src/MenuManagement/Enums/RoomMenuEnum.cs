using Hotel.src.MenuManagement.Enums.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Enums
{
    public enum RoomMenuOptions
    {
        [Description("Föregående meny")]
        PreviousMenu,
        [Description("Bokningshantering")]
        BookingManagement,
        [Description("Kundhantering")]
        CustomerManagement,
        [Description("Rumhantering")]
        RoomManagement,
        [Description("Admin")]
        Admin,
        [Description("Avsluta")]
        Exit
    }

    public static class RoomMenuEnum
    {
        public static string ShowCustomerMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }
    }
}
