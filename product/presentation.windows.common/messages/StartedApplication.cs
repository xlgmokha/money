using System;
using ProtoBuf;

namespace presentation.windows.common.messages
{
    [Serializable]
    [ProtoContract]
    public class StartedApplication
    {
        [ProtoMember(1)]
        public string message { get; set; }

        public override string ToString()
        {
            return base.ToString() + message;
        }
    }
}