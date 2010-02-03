using System;

namespace tests
{
    public class call
    {
        public static Action to(Action action)
        {
            return action;
        }
    }
}