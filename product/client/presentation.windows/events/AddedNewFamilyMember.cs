using System;
using MoMoney.Service.Infrastructure.Eventing;

namespace presentation.windows.events
{
    public class AddedNewFamilyMember : IEvent
    {
        public Guid id { get; set; }

        public string first_name { get; set; }
    }
}