using System;

namespace MoMoney.Utility.Core
{
    internal class DisposableCommand : IDisposableCommand
    {
        readonly Action action;

        public DisposableCommand(Action action)
        {
            this.action = action;
        }

        public void run()
        {
            action();
        }

        public void Dispose()
        {
        }
    }
}