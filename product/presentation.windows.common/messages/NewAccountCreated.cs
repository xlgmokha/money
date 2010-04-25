using System;
using ProtoBuf;

namespace presentation.windows.common.messages
{
    [Serializable]
    [ProtoContract]
    public class NewAccountCreated
    {
        [ProtoMember(1)]
        public string name { get; set; }
    }
}