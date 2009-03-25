using System;

namespace MoMoney.Utility.Extensions
{
    static public class TypeExtensions
    {
        static public Type last_interface(this Type type)
        {
            return type.GetInterfaces()[type.GetInterfaces().Length - 1];
        }

        static public Type first_interface(this Type type)
        {
            return type.GetInterfaces()[0];
        }

        static public bool is_a_generic_type(this Type type)
        {
            //return type.IsGenericType;
            return type.IsGenericTypeDefinition;
        }

        static public object default_value(this Type type)
        {
            return (type.IsValueType ? Activator.CreateInstance(type) : null);
        }
    }
}