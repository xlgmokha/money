using MyMoney.Infrastructure.Threading;
using MyMoney.Utility.Core;

namespace MyMoney.Infrastructure.Extensions
{
    public static class threading_extensions
    {
        public static IBackgroundThread on_a_background_thread(this IDisposableCommand command)
        {
            var background_thread = new background_thread(command);
            background_thread.run();
            return background_thread;
        }
    }
}