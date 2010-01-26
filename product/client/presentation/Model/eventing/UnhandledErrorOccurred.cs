using System;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.model.eventing
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