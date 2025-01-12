using Hotel.src.MenuManagement.Enums.Services;
using System.ComponentModel;

namespace Hotel.src.MenuManagement.Enums
{
    public enum MainMenuOptions
    {
        [Description("<--")]
        PreviousMenu,
        [Description("  Bokningar")]
        BookingManagement,
        [Description("  Rumhantering")]
        RoomManagement,
        [Description("  Kundhantering")]
        CustomerManagement,
        [Description("  Fakturahantering")]
        InvoiceManagement,
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
