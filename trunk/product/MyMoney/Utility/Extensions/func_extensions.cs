using System;

namespace MyMoney.Utility.Extensions
{
    public static class func_extensions
    {
        public static Func<T> memorize<T>(this Func<T> item) where T : class
        {
            T the_implementation = null;
            return () => {
                       if (null == the_implementation) {
                           the_implementation = item();
                       }
                       return the_implementation;
                   };
        }
    }
}