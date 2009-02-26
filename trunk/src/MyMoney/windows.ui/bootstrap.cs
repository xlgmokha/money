using System;
using MyMoney.Utility.Extensions;

namespace MyMoney.windows.ui
{
    internal static class bootstrap
    {
        [STAThread]
        private static void Main()
        {
            hookup.the<global_error_handling>()
                .then<wire_up_the_container>()
                //.then<check_for_updates>()
                .then<start_the_application>()
                .run();
        }
    }
}