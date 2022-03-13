using System.Reflection;

namespace DataBaseProject.Utils
{
    public static class EnumName
    {
        public static TAttribute? GetAttribute<TAttribute>(this Enum enumValue) where
            TAttribute : Attribute => enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<TAttribute>();
    }
}
