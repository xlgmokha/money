using System;

namespace MyMoney.Infrastructure.Extensions
{
    public static class environment_extensions
    {
        public static string startup_directory<T>(this T item)
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}