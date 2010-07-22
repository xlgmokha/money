using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows;
using System.Windows.Threading;
using Gorilla.Commons.Infrastructure.Logging;
using presentation.windows.bootstrappers;
using presentation.windows.views;

namespace presentation.windows
{
    static public class Program
    {
        [STAThread]
        static public void Main(string[] args)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = get_service_startup_path(args),
                //WindowStyle = ProcessWindowStyle.Hidden,
            });
            AppDomain.CurrentDomain.UnhandledException += (o, e) =>
            {
                (e.ExceptionObject as Exception).add_to_log();
            };
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            Dispatcher.CurrentDispatcher.UnhandledException += (o, e) =>
            {
                e.Exception.add_to_log();
                new ErrorWindow {DataContext = e.Exception}.ShowDialog();
                e.Handled = true;
            };
            new WPFApplication
            {
                ShutdownMode = ShutdownMode.OnMainWindowClose,
            }.Run(ClientBootstrapper.create_window());
        }

        static string get_service_startup_path(string[] args)
        {
            if (args.Length > 0)
                return Path.Combine(args[0], @"momoney.server.exe");
            return Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\server\bin\Debug\momoney.server.exe"));
        }
    }
}