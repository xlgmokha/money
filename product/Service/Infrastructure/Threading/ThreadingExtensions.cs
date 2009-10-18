using MoMoney.Utility.Core;

namespace MoMoney.Service.Infrastructure.Threading
{
    public static class ThreadingExtensions
    {
        public static IBackgroundThread on_a_background_thread(this IDisposableCommand command)
        {
            return new BackgroundThread(command);
        }
    }
}