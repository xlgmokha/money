using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Transactions;
using Gorilla.Commons.Infrastructure.Logging;
using presentation.windows.common;
using Rhino.Queues;

namespace presentation.windows.server
{
    public class StartServiceBus : NeedStartup
    {
        bool running = true;

        public void run()
        {
            var manager = new QueueManager(new IPEndPoint(IPAddress.Loopback, 2200), "receiver.esent");
            manager.CreateQueues("server");
            var queue = manager.GetQueue("server");

            while (running)
            {
                using (var transaction = new TransactionScope())
                {
                    var message = queue.Receive();
                    this.log().debug(message.Headers["Source"]);
                    this.log().debug(Encoding.Unicode.GetString(message.Data));
                    Console.Out.WriteLine(message.Headers["Source"]);
                    Console.Out.WriteLine(Encoding.Unicode.GetString(message.Data));
                    transaction.Complete();
                }
            }
        }
    }

    public class RhinoBus : ServiceBus
    {
        BinaryFormatter formatter = new BinaryFormatter();

        public void publish<T>() where T : new()
        {
            publish(new T());
        }

        public void publish<T>(T item) where T : new()
        {
			using (var sender = new QueueManager(new IPEndPoint(IPAddress.Loopback, 4546), "sender.esent"))
			{
				using (var tx = new TransactionScope())
				{
                    var buffer = new byte[int.MaxValue];
                    using (var stream = new MemoryStream(buffer))
                    {
                        formatter.Serialize(stream, item);
                        sender.Send(new Uri("rhino.queues://localhost:4545/uno"), new MessagePayload
                                           {
                                               Headers = new NameValueCollection(),
                                               Data = buffer
                                           });
                    }
					tx.Complete();
				}
				sender.WaitForAllMessagesToBeSent();
			}
        }

        public void publish<T>(Action<T> configure) where T : new()
        {
            var item = new T();
            configure(item);
            publish(item);
        }
    }
}