using System;
using System.Collections.Generic;
using System.Transactions;
using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.infrastructure.threading;
using gorilla.commons.utility;
using Rhino.Queues;
using Rhino.Queues.Model;

namespace presentation.windows.common
{
    public class RhinoReceiver : Receiver
    {
        List<Observer<Message>> observers = new List<Observer<Message>>();
        IQueue queue;
        CommandProcessor processor;

        public RhinoReceiver(IQueue queue, CommandProcessor processor)
        {
            this.queue = queue;
            this.processor = processor;
        }

        public void register(Observer<Message> observer)
        {
            observers.Add(observer);
        }

        public void run()
        {
            try
            {
                var message = next_message();
                observers.each(observer => observer(message));
            }
            catch (Exception e)
            {
                e.add_to_log();
            }
            finally
            {
                processor.add(this);
            }
        }

        Message next_message()
        {
            Message message;
            using (var transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                message = queue.Receive();
                transaction.Complete();
            }
            return message;
        }
    }
}