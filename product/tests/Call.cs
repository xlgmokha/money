using System;

namespace tests
{
    public class call
    {
        static public Action to(Action action)
        {
            return action;
        }
    }
}