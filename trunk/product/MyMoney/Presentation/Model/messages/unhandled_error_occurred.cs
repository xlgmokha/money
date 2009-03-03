using System;
using MyMoney.Infrastructure.eventing;

namespace MyMoney.Presentation.Model.messages
{
    public class unhandled_error_occurred : IEvent
    {
        public unhandled_error_occurred(Exception error)
        {
            this.error = error;
        }

        public Exception error { get; private set; }
    }
}