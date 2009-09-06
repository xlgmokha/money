using System.Windows.Forms;
using MoMoney.Service.Infrastructure.Threading;

namespace MoMoney.Presentation.Core
{
    public interface IApplication
    {
        void shut_down();
        void restart();
    }

    public class ApplicationEnvironment : IApplication
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