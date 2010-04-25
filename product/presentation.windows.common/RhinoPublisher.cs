using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Transactions;
using gorilla.commons.utility;
using Rhino.Queues;

namespace presentation.windows.common
{
    public class RhinoPublisher : ServiceBus
    {
        BinaryFormatter formatter = new BinaryFormatter();
        readonly int port;
        string destination_queue;
        IQueueManager sender;

        public RhinoPublisher(string destination_queue, int port, IQueueManager manager)
        {
            this.port = port;
            this.destination_queue = destination_queue;
            sender = manager;
        }

        public void publish<T>() where T : new()
        {
            publish(new T());
        }

        public void publish<T>(T item) where T : new()
        {
            using (var tx = new TransactionScope())
            {
                var buffer = new byte[255];
                using (var stream = new MemoryStream(buffer))
                {
                    formatter.Serialize(stream, item);
                    sender.Send(new Uri("rhino.queues://localhost:{0}/{1}".formatted_using(port, destination_queue)), new MessagePayload {Data = buffer});
                }
                tx.Complete();
            }
            //sender.WaitForAllMessagesToBeSent();
        }

        public void publish<T>(Action<T> configure) where T : new()
        {
            var item = new T();
            configure(item);
            publish(item);
        }
    }
}