using MoMoney.Utility.Core;

namespace MoMoney.Utility.Extensions
{
    public static class configuration_extensions
    {
        public static IConfiguration<T> then<T>(this IConfiguration<T> first, IConfiguration<T> second)
        {
            return new ChainedConfiguration<T>(first, second);
        }
    }
}