using MoMoney.Infrastructure.Threading;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Extensions
{
    public static class threading_extensions
    {
        public static IBackgroundThread on_a_background_thread(this IDisposableCommand command)
        {
            var background_thread = new BackgroundThread(command);
            background_thread.run();
            return background_thread;
        }
    }
}