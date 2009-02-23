namespace MyMoney.Utility.Extensions
{
    public static class string_extensions
    {
        public static string formatted_using(this string formattedString, params object[] arguments)
        {
            return string.Format(formattedString, arguments);
        }

        public static bool is_equal_to_ignoring_case(this string left, string right)
        {
            return string.Compare(left, right, true) == 0;
        }

        public static bool is_blank(this string message)
        {
            return string.IsNullOrEmpty(message);
        }

        public static string to_string<T>(this T item)
        {
            return "{0}".formatted_using(item);
        }
    }
}