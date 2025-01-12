using Hotel.src.MenuManagement.Enums.Services;
using System.ComponentModel;

namespace Hotel.src.MenuManagement.Enums
{
    public enum CleaningMenuOptions
    {
        [Description("<-->")]
        PreviousMenu,
        [Description("  Visa utförda städningar")]
        DisplayRooms,
        [Description("  Registrera ny städning")]
        UpdateRooms,
        [Description("Avsluta")]
        Exit
    }

    public static class CleaningMenuEnum
    {
        public static string ShowCleaningMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }
    }
}
