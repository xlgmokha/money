using gorilla.commons.Utility;

namespace gorilla.commons.infrastructure.threading
{
    static public class ThreadingExtensions
    {
        static public IBackgroundThread on_a_background_thread(this DisposableCommand command)
        {
            return new BackgroundThread(command);
        }
    }
}