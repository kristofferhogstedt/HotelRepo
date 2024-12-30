using Hotel.src.MenuManagement;
using Hotel.src.MenuManagement.Enums.Services;
using Hotel.src.MenuManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Enums
{
    public enum MainMenuOptions
    {
        [Description("Föregående meny")]
        PreviousMenu,
        [Description("Bokningshantering")]
        BookingManagement,
        [Description("Kundhantering")]
        CustomerManagement,
        [Description("Rumhantering")]
        RoomManagement,
        [Description("Städhantering")]
        CleaningManagement,
        [Description("Fakturahantering")]
        EconomyManagement,
        [Description("Admin")]
        Admin,
        [Description("Avsluta")]
        Exit
    }

    public static class MainMenuEnum
    {
        public static string ShowMainMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }
    }
}
