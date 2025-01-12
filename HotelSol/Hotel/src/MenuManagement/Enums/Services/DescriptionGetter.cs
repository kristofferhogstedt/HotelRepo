using System.ComponentModel;
using System.Reflection;

namespace Hotel.src.MenuManagement.Enums.Services
{
    public static class DescriptionGetter
    {
        public static string GetDescription(Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (field == null)
            {
                return enumValue.ToString();
            }
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute != null ? attribute.Description : enumValue.ToString();
        }
    }
}
