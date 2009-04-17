namespace MoMoney.Utility.Core
{
    public interface IComponentFactory<T> : IFactory<T> where T : new()
    {
    }

    public class Factory<T> : IComponentFactory<T> where T : new()
    {
        public T create()
        {
            return new T();
        }
    }
}