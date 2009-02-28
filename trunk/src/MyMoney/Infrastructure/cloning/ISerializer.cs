using System;

namespace MyMoney.Infrastructure.cloning
{
    public interface ISerializer<T> : IDisposable
    {
        void serialize(T to_serialize);
        T deserialize();
    }
}