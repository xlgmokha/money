using System;
using ProtoBuf;

namespace presentation.windows.common.messages
{
    [Serializable]
    [ProtoContract]
    public class CreateNewAccount
    {
        [ProtoMember(1)]
        public string account_name { get; set; }
        [ProtoMember(2)]
        public string currency { get; set; }
    }
}