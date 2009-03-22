using System;

namespace MoMoney.Utility.Extensions
{
    public static class TypeExtensions
    {
        public static Type last_interface(this Type type)
        {
            return type.GetInterfaces()[type.GetInterfaces().Length - 1];
        }

        public static Type first_interface(this Type type)
        {
            return type.GetInterfaces()[0];
        }

        public static bool is_a_generic_type(this Type type)
        {
            //return type.IsGenericType;
            return type.IsGenericTypeDefinition;
        }
    }
}