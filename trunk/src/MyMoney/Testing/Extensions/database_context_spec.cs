using MyMoney.Domain.Core;
using MyMoney.Infrastructure.Container;
using MyMoney.Testing.MetaData;

namespace MyMoney.Testing.Extensions
{
    [run_in_real_container]
    public abstract class database_context_spec : old_context_specification<IRepository>
    {
        protected override IRepository context()
        {
            return resolve.dependency_for<IRepository>();
        }
    }
}