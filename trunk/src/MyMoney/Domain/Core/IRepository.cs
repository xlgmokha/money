using System.Collections.Generic;

namespace MyMoney.Domain.Core
{
    public interface IRepository
    {
        IEnumerable<T> all<T>() where T : IEntity;
        void save<T>(T item) where T : IEntity;
    }
}