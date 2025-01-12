using Hotel.src.MenuManagement.Enums.Services;
using System.ComponentModel;

namespace Hotel.src.MenuManagement.Enums
{
    public enum CustomerMenuOptions
    {
        [Description("<--")]
        PreviousMenu,
        [Description("  Visa kunder")]
        DisplayCustomer,
        [Description("  Registrera ny kund")]
        CreateCustomer,
        [Description("  Visa inaktiverade")]
        DisplayInactive,
        [Description("Avsluta")]
        Exit
    }

    public static class CustomerMenuEnum
    {
        public static string ShowCustomerMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }
    }
}
