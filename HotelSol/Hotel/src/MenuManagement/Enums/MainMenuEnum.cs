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
        [Description("Admin")]
        Admin,
        [Description("Avsluta")]
        Exit
    }

    public static class MainMenuEnum //: Menu, IMenu, IPreviousMenu
    {
        public static string ShowMainMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }

        //Dictionary<int, string> MenuSelection { get; init; }
        //IPreviousMenu _previousMenu;

        //public MainMenu(IPreviousMenu previousMenu) : base(previousMenu)
        //{
        //    _previousMenu = previousMenu;
        //    MenuSelection = new Dictionary<int, string>();
        //    MenuSelection.Add(0, "Föregående meny");
        //    MenuSelection.Add(1, "Artikelhantering");
        //    MenuSelection.Add(2, "Kampanjhantering");
        //    MenuSelection.Add(9, "Avsluta");
        //}

        //public static string GetDescription(this Enum enumValue)
        //{
        //    var field = enumValue.GetType().GetField(enumValue.ToString());
        //    if (field == null)
        //    {
        //        return enumValue.ToString();
        //    }

        //    var attribute = field.GetCustomAttribute<DescriptionAttribute>();
        //    return attribute != null ? attribute.Description : enumValue.ToString();
        //}
    }
}
