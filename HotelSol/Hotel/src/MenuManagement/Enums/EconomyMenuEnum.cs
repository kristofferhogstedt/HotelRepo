using Hotel.src.MenuManagement.Enums.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Enums
{
    public enum EconomyMenuOptions
    {
        [Description("Föregående meny")]
        PreviousMenu,
        [Description("Visa fakturor")]
        DisplayInvoices,
        [Description("Uppdatera faktura")]
        UpdateInvoices,
        [Description("Avsluta")]
        Exit
    }

    public static class EconomyMenuEnum
    {
        public static string ShowEconomyMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }
    }
}
