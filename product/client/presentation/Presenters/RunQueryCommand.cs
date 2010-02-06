using gorilla.commons.utility;
using MoMoney.Presentation.Presenters;

namespace momoney.presentation.presenters
{
    public class RunQueryCommand<T> : Command
    {
        readonly Callback<T> callback;
        readonly IProcessQueryCommand<T> command;

        public RunQueryCommand(Callback<T> callback, IProcessQueryCommand<T> command)
        {
            this.callback = callback;
            this.command = command;
        }

        public void run()
        {
            command.run_against(callback);
        }
    }
}