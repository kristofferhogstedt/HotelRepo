using Hotel.src.MenuManagement.Enums.Services;
using System.ComponentModel;

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
        InvoiceManagement,
        //[Description("Admin")]
        //Admin,
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
