using System;
using MoMoney.Service.Infrastructure.Eventing;

namespace presentation.windows.common.messages
{
    [Serializable]
    public class AddedNewFamilyMember : IEvent
    {
        public Guid id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}