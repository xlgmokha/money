using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Transactions;
using gorilla.commons.utility;
using Rhino.Queues;

namespace presentation.windows.common
{
    public class RhinoPublisher : ServiceBus
    {
        BinaryFormatter formatter = new BinaryFormatter();
        readonly int send_port;
        string destination_queue;
        QueueManager sender;

        public RhinoPublisher(int listen_port, string destination_queue, string esent, int send_port)
        {
            this.send_port = send_port;
            this.destination_queue = destination_queue;

            if (Directory.Exists(esent)) Directory.Delete(esent, true);
            sender = new QueueManager(new IPEndPoint(IPAddress.Loopback, listen_port), esent);
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
                    sender.Send(new Uri("rhino.queues://localhost:{0}/{1}".formatted_using(send_port, destination_queue)), new MessagePayload {Data = buffer});
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