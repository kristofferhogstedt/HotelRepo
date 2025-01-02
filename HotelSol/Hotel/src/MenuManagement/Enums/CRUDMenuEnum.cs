using Hotel.src.MenuManagement.Enums.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Enums
{
    public enum CustomerCRUDMenuOptions
    {
        [Description("Föregående meny")]
        PreviousMenu,
        [Description("Redigera")]
        Update,
        [Description("Inaktivera")]
        Inactivate,
        [Description("Avsluta")]
        Exit
    }

    public static class CRUDMenuEnum
    {
        public static string ShowCustomerCRUDMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);
        }
    }
}
