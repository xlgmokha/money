using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;
using Rhino.Queues.Model;

namespace presentation.windows.common
{
    public class MessageHandler
    {
        BinaryFormatter formatter = new BinaryFormatter();
        DependencyRegistry registry;

        public MessageHandler(DependencyRegistry registry)
        {
            this.registry = registry;
        }

        public void handler(Message item)
        {
            using (var stream = new MemoryStream(item.Data))
            {
                var payload = formatter.Deserialize(stream);
                registry.get_all<Handler>().where(x => x.can_handle(payload.GetType())).each(x => x.handle(payload));
                this.log().debug("received: {0}", payload);
            }
        }
    }
}