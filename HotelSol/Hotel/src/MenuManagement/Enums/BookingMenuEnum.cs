using Hotel.src.MenuManagement.Enums.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Enums
{
    public enum BookingMenuOptions
    {
        [Description("<--")]
        PreviousMenu,
        [Description("  Visa bokningar")]
        DisplayBookings,
        [Description("  Registrera ny bokning")]
        CreateBooking,
		[Description("  Visa inaktiverade")]
		DisplayInactive,
		[Description("Avsluta")]
        Exit
    }

    public static class BookingMenuEnum
    {
        public static string ShowBookingMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }
    }
}
