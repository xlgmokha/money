using System;
using System.Diagnostics;
using System.IO;
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
        static public void Main(string[] args)
        {
            Process.Start(get_startup_path_using(args));
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

        static string get_startup_path_using(string[] args)
        {
            if (args.Length > 0)
                return Path.Combine(args[0], @"presentation.windows.server.exe");
            return Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\server\bin\Debug\presentation.windows.server.exe"));
        }
    }
}