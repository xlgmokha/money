using System;

namespace MoMoney.Testing
{
    public class call
    {
        public static Action to(Action action)
        {
            return action;
        }
    }
}