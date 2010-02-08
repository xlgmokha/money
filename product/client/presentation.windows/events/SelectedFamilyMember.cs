using System;
using MoMoney.Service.Infrastructure.Eventing;

namespace presentation.windows.events
{
    public class SelectedFamilyMember : IEvent
    {
        public Guid id { get; set; }
    }
}