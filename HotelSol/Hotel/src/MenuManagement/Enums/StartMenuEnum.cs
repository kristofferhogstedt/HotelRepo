using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.src.MenuManagement.Enums
{
    public enum MainMenuOptions
    {
        [Description("Login")]
        Login,
        [Description("AdminLogin")]
        AdminLogin,
        [Description("Avsluta")]
        Exit
    }

    public static class StartMenuEnum //: MenuEnum
    {
        public static string ShowStartMenu(this Enum enumValues)
        {
            return DescriptionGetter.GetDescription(enumValues);

        }

        //public static string GetDescription(this Enum enumValue)
        //{
        //    var field = enumValue.GetType().GetField(enumValue.ToString());
        //    if (field == null)
        //    {
        //        return enumValue.ToString();
        //    }
        //    var attribute = field.GetCustomAttribute<DescriptionAttribute>();
        //    return attribute != null ? attribute.Description : enumValue.ToString();
        //}
    }
}
