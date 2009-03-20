using System;

namespace MoMoney.Utility.Core
{
    public class ActionCommand : ICommand
    {
        Action action;

        public ActionCommand(Action action)
        {
            this.action = action;
        }

        public void run()
        {
            action();
        }
    }
}