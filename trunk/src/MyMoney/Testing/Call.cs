using System;

namespace MyMoney.Testing
{
    public class call
    {
        public static Action to(Action action)
        {
            return action;
        }
    }
}