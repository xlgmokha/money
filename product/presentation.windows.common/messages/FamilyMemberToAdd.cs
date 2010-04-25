using System;
using ProtoBuf;

namespace presentation.windows.common.messages
{
    [Serializable]
    [ProtoContract]
    public class FamilyMemberToAdd
    {
        [ProtoMember(1)]
        public string first_name { get; set; }
        [ProtoMember(2)]
        public string last_name { get; set; }
        [ProtoMember(3)]
        public DateTime date_of_birth { get; set; }
    }
}