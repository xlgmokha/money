using System.Threading;

namespace momoney.database.transactions
{
    public class CurrentThread : IThread
    {
        public T provide_slot_for<T>() where T : class, new()
        {
            var slot = Thread.GetNamedDataSlot(create_key_for<T>());
            if (null == Thread.GetData(slot)) Thread.SetData(slot, new T());
            return (T) Thread.GetData(slot);
        }

        string create_key_for<T>()
        {
            return Thread.CurrentThread.ManagedThreadId + GetType().FullName + typeof (T).FullName;
        }
    }
}