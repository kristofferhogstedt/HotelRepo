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
        [Description("<--")]
        PreviousMenu,
        [Description("  Visa rum")]
        DisplayRooms,
        [Description("  Registrera nytt rum")]
        CreateRoom,
        [Description("Avsluta")]
        Exit
        //[Description("  Uppdatera rum")]
        //UpdateRooms,
        //[Description("  Radera rum")]
        //DeleteRooms,
    }

    public static class RoomMenuEnum
    {
        public static string ShowRoomMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }
    }
}
