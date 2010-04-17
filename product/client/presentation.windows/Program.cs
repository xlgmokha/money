using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows;
using System.Windows.Threading;
using presentation.windows.bootstrappers;
using presentation.windows.views;

namespace presentation.windows
{
    static public class Program
    {
        [STAThread]
        static public void Main()
        {
            Process.Start("presentation.windows.server.exe");
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            Dispatcher.CurrentDispatcher.UnhandledException += (o, e) =>
            {
                new ErrorWindow {DataContext = e.Exception}.ShowDialog();
            };
            new Application
            {
                ShutdownMode = ShutdownMode.OnMainWindowClose
            }.Run(Bootstrapper.create_window());
        }
    }
}