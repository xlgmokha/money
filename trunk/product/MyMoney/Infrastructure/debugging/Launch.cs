using System.Diagnostics;

namespace MyMoney.Infrastructure.debugging
{
    public static class Launch
    {
        public static void the_debugger()
        {
#if DEBUG
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
            else
            {
                Debugger.Launch();
            }
#endif
        }
    }
}