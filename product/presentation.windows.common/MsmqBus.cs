using System;
using System.Messaging;

namespace presentation.windows.common
{
    public class MsmqBus : ServiceBus
    {
        MessageQueue queue;

        public MsmqBus(MessageQueue queue)
        {
            this.queue = queue;
            queue.ReceiveCompleted += (sender, args) =>
            {
                var message = queue.EndReceive(args.AsyncResult);
                process(message);
                queue.BeginReceive();
            };
            queue.BeginReceive();
        }

        public void publish<T>() where T : new()
        {
            publish(new T());
        }

        public void publish<T>(T item) where T : new()
        {
            queue.Send(item);
        }

        public void publish<T>(Action<T> configure) where T : new()
        {
            var item = new T();
            configure(item);
            publish(item);
        }

        void process(Message message) { }
    }
}