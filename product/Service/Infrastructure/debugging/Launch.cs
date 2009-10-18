using System;
using System.Diagnostics;

namespace MoMoney.Service.Infrastructure.debugging
{
    static public class Launch
    {
        static public void the_debugger()
        {
#if DEBUG
            if (Debugger.IsAttached) Debugger.Break();
            else Debugger.Launch();
#endif
        }

        static public void the_debugger_if(Func<bool> condition)
        {
#if DEBUG
            if (!condition()) return;

            if (Debugger.IsAttached) Debugger.Break();
            else Debugger.Launch();
#endif
        }
    }
}