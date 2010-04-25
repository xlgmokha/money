using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Transactions;
using gorilla.commons.utility;
using Rhino.Queues;
using Rhino.Queues.Model;

namespace presentation.windows.common
{
    public class RhinoReceiver : Receiver
    {
        bool running = true;
        List<Observer<Message>> observers = new List<Observer<Message>>();
        string queue_name;
        IQueue queue;

        public RhinoReceiver(int port, string queue_name, string esent_name)
        {
            this.queue_name = queue_name;

            if (Directory.Exists(esent_name)) Directory.Delete(esent_name, true);
            var manager = new QueueManager(new IPEndPoint(IPAddress.Loopback, port), esent_name);
            manager.CreateQueues(this.queue_name);
            queue = manager.GetQueue(this.queue_name);
        }

        public void register(Observer<Message> observer)
        {
            observers.Add(observer);
        }

        public void run()
        {
            running = true;
            while (running)
            {
                using (var transaction = new TransactionScope())
                {
                    var message = queue.Receive();
                    observers.each(x => x(message));
                    transaction.Complete();
                }
            }
        }

        public void stop()
        {
            running = false;
        }
    }
}