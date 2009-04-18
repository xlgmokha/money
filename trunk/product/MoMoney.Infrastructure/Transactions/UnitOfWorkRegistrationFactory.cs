using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.cloning;

namespace MoMoney.Infrastructure.transactions
{
    //public interface IUnitOfWorkRegistrationFactory<T> : IMapper<T, IUnitOfWorkRegistration<T>>
    //{
    //}

    //public class UnitOfWorkRegistrationFactory<T> : IUnitOfWorkRegistrationFactory<T>
    //{
    //    readonly IPrototype prototype;

    //    public UnitOfWorkRegistrationFactory(IPrototype prototype)
    //    {
    //        this.prototype = prototype;
    //    }

    //    public IUnitOfWorkRegistration<T> map_from(T item)
    //    {
    //        return new UnitOfWorkRegistration<T>(create_prototype(item), item);
    //    }

    //    T create_prototype(T item)
    //    {
    //        return prototype.clone(item);
    //    }
    //}
}