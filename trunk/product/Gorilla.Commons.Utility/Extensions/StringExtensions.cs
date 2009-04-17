namespace Gorilla.Commons.Utility.Extensions
{
    public static class StringExtensions
    {
        public static string formatted_using(this string formatted_string, params object[] arguments)
        {
            return string.Format(formatted_string, arguments);
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