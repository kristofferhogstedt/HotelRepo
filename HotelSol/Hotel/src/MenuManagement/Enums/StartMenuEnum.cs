using Hotel.src.MenuManagement.Enums.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Enums
{
    public enum StartMenuOptions
    {
        [Description("Login")]
        Login,
        //[Description("AdminLogin")]
        //AdminLogin,
        [Description("Avsluta")]
        Exit
    }

    public static class StartMenuEnum 
    {
        public static string ShowStartMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);

        }
    }
}
