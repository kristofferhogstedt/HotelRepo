using Hotel.src.MenuManagement.Enums.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Description("Avsluta")]
        Exit
        //[Description("  Se alla kunder")]
        //DisplayCustomerAll,
        //[Description("  Redigera kund")]
        //UpdateCustomer,
        //[Description("Radera kund")]
        //DeleteCustomer,
    }

    public static class CustomerMenuEnum 
    {
        public static string ShowCustomerMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }
    }
}
