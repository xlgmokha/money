using System.Windows.Forms;

namespace MyMoney.Infrastructure.System
{
    public interface IApplicationEnvironment
    {
        void shut_down();
        void restart();
    }

    public class application_environment : IApplicationEnvironment
    {
        public void shut_down()
        {
            Application.Exit();
            //Environment.Exit(Environment.ExitCode);
        }

        public void restart()
        {
            Application.Restart();
        }
    }
}