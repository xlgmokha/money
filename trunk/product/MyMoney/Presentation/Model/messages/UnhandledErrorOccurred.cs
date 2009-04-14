using System;
using MoMoney.Infrastructure.eventing;

namespace MoMoney.Presentation.Model.messages
{
    public class UnhandledErrorOccurred : IEvent
    {
        public UnhandledErrorOccurred(Exception error)
        {
            this.error = error;
        }

        public Exception error { get; private set; }
    }
}