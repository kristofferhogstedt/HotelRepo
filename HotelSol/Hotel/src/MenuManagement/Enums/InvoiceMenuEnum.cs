using Hotel.src.MenuManagement.Enums.Services;
using System.ComponentModel;

namespace Hotel.src.MenuManagement.Enums
{
    public enum InvoiceMenuOptions
    {
        [Description("<--")]
        PreviousMenu,
        [Description("  Visa fakturor")]
        DisplayInvoices,
        [Description("Avsluta")]
        Exit
    }

    public static class InvoiceMenuEnum
    {
        public static string ShowInvoiceMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }
    }
}
