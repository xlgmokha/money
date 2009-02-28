using System;

namespace MyMoney.Utility.Core
{
    internal class command : IDisposableCommand
    {
        private readonly Action action;

        public command(Action action)
        {
            this.action = action;
        }

        public void run()
        {
            action();
        }

        public void Dispose()
        {}
    }
}