using System.Windows.Forms;

namespace MyMoney.Infrastructure.System
{
    public interface IApplicationEnvironment
    {
        void ShutDown();
    }

    public class application_environment : IApplicationEnvironment
    {
        public void ShutDown()
        {
            Application.Exit();
            //Environment.Exit(Environment.ExitCode);
        }
    }
}