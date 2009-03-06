using System;

namespace MoMoney.Utility.Extensions
{
    public static class conversion_extensions
    {
        public static T downcast_to<T>(this object object_to_cast)
        {
            return (T) object_to_cast;
        }

        public static T converted_to<T>(this object item_to_convert)
        {
            if (item_to_convert.is_an_implementation_of<IConvertible>()) {
                return (T) Convert.ChangeType(item_to_convert, typeof (T));
            }
            return item_to_convert.downcast_to<T>();
        }

        public static bool is_an_implementation_of<T>(this object item)
        {
            return item is T;
        }
    }
}