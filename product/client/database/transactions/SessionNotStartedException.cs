using System;

namespace momoney.database.transactions
{
    public class SessionNotStartedException : Exception
    {
        public SessionNotStartedException() : base("A session could not be found. Did you forget to open a session?")
        {
        }
    }
}