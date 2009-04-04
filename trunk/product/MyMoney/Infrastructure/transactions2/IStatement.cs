using Db4objects.Db4o;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IStatement
    {
        void prepare(IObjectContainer connection);
    }
}