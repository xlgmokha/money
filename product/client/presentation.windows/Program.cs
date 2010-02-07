using System;
using System.Security.Principal;
using System.Windows;
using presentation.windows.bootstrappers;
using presentation.windows.views;

namespace presentation.windows
{
    static public class Program
    {
        [STAThread]
        static public void Main()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            var application = new Application();
            application.DispatcherUnhandledException += (o, e) =>
            {
                new ErrorWindow {DataContext = e.Exception}.ShowDialog();
            };
            application.ShutdownMode = ShutdownMode.OnMainWindowClose;
            application.Run(Bootstrapper.create_window());
        }
    }
}