using gorilla.commons.utility;
using MoMoney.Presentation.Presenters;

namespace momoney.presentation.presenters
{
    public interface IRunQueryCommand<T> : Command {}

    public class RunQueryCommand<T> : IRunQueryCommand<T>
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
            command.run(callback);
        }
    }
}