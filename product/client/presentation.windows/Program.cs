using System;
using System.Windows;

namespace presentation.windows
{
    static public class Program
    {
        [STAThread]
        static public void Main()
        {
            var application = new Application();
            application.DispatcherUnhandledException += (o, e) => {};
            application.ShutdownMode = ShutdownMode.OnMainWindowClose;
            application.Run(new ShellWindow());
        }
    }
}