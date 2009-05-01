using System;

namespace Gorilla.Commons.Infrastructure.Experiments
{
    internal class ObjectUsageHasExpiredException : Exception
    {
        public ObjectUsageHasExpiredException(Type type, string date_time) : base(build_message(type, date_time))
        {
        }

        static string build_message(Type type, string date_time)
        {
            return string.Format("Cannot use {0} after {1}.", type.Name, date_time);
        }
    }
}