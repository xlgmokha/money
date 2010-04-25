using System.Collections.Generic;
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
        IQueue queue;

        public RhinoReceiver(IQueue queue)
        {
            this.queue = queue;
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