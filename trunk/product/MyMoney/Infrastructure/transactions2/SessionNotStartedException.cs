using System;

namespace MoMoney.Infrastructure.transactions2
{
    public class SessionNotStartedException : Exception
    {
        public SessionNotStartedException() : base("A session could not be found. Did you forget to open a session?")
        {
        }
    }
}