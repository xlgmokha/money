using System;
using MoMoney.Service.Infrastructure.Eventing;

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