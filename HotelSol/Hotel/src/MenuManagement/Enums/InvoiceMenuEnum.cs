using Hotel.src.MenuManagement.Enums.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //[Description("  Skapa faktura")]
        //CreateInvoices,
    }

    public static class InvoiceMenuEnum
    {
        public static string ShowInvoiceMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }
    }
}
