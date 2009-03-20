using MoMoney.Infrastructure.Threading;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Extensions
{
    public static class threading_extensions
    {
        public static IBackgroundThread on_a_background_thread(this IDisposableCommand command)
        {
            return new BackgroundThread(command);
        }
    }
}