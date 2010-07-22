using gorilla.commons.utility;

namespace presentation.windows.common
{
    public interface NeedStartup : Command {}

    public interface NeedsShutdown : Command {}
}