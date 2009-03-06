using System;
using MoMoney.Infrastructure.eventing;

namespace MoMoney.Presentation.Model.messages
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