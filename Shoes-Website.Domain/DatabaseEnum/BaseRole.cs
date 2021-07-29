using System;
using System.ComponentModel;

namespace Shoes_Website.Domain.DatabaseEnum
{
    public enum BaseRole
    {
        [Description("Global Admin")]
        Admin = 1,

        [Description("User")]
        User = 2
    }

    public static class EnumExtensionMethods
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
    }
}
