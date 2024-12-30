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
        [Description("Föregående meny")]
        PreviousMenu,
        [Description("Se kunder")]
        DisplayCustomers,
        [Description("Uppdatera kund")]
        UpdateCustomer,
        [Description("Registrera ny kund")]
        CreateCustomer,
        [Description("Radera kund")]
        DeleteCustomer,
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
