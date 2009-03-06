using System;

namespace MoMoney.Utility.Extensions
{
    public static class type_extensions
    {
        public static Type get_the_last_interface(this Type type)
        {
            return type.GetInterfaces()[type.GetInterfaces().Length - 1];
        }
    }
}