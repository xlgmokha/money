using System;
using MoMoney.Service.Infrastructure.Eventing;
using ProtoBuf;

namespace presentation.windows.common.messages
{
    [Serializable]
    [ProtoContract]
    public class AddedNewFamilyMember : IEvent
    {
        [ProtoMember(1)]
        public Guid id { get; set; }
        [ProtoMember(2)]
        public string first_name { get; set; }
        [ProtoMember(3)]
        public string last_name { get; set; }
    }
}