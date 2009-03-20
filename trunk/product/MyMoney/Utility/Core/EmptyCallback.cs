namespace MoMoney.Utility.Core
{
    public class EmptyCallback<T> : ICallback<T>, ICallback
    {
        public void complete(T item)
        {
        }

        public void complete()
        {
        }
    }
}