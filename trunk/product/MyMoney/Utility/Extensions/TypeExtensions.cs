using System;

namespace MoMoney.Utility.Extensions
{
    public static class TypeExtensions
    {
        public static Type last_interface(this Type type)
        {
            return type.GetInterfaces()[type.GetInterfaces().Length - 1];
        }
    }
}