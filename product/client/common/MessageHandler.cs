using System;
using System.IO;
using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;
using ProtoBuf;
using Rhino.Queues.Model;

namespace presentation.windows.common
{
    public class MessageHandler : Handler<Message>
    {
        DependencyRegistry registry;

        public MessageHandler(DependencyRegistry registry)
        {
            this.registry = registry;
        }

        public void handle(Message item)
        {
            var payload = parse_payload_from(item);
            registry
                .get_all<Handler>()
                .each(x => x.handle(payload));
        }

        object parse_payload_from(Message item)
        {
            using (var stream = new MemoryStream(item.Data))
            {
                return Serializer.NonGeneric.Deserialize(Type.GetType(item.Headers["type"]), stream);
            }
        }
    }
}