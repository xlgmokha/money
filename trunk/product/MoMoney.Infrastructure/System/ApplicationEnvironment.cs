using System.Windows.Forms;
using MoMoney.Infrastructure.Threading;

namespace MoMoney.Infrastructure.System
{
    public interface IApplicationEnvironment
    {
        void shut_down();
        void restart();
    }

    public class ApplicationEnvironment : IApplicationEnvironment
    {
        readonly ICommandProcessor processor;

        public ApplicationEnvironment(ICommandProcessor processor)
        {
            this.processor = processor;
        }

        public void shut_down()
        {
            processor.stop();
            Application.Exit();
            //Environment.Exit(Environment.ExitCode);
        }

        public void restart()
        {
            processor.stop();
            Application.Restart();
        }
    }
}