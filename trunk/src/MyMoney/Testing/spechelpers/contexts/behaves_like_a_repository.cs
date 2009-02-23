using MyMoney.Domain.Core;
using MyMoney.Infrastructure.Container;
using MyMoney.Testing.MetaData;

namespace MyMoney.Testing.spechelpers.contexts
{
    [run_in_real_container]
    [Concern(typeof (IRepository))]
    public abstract class behaves_like_a_repository : concerns_for<IRepository>
    {
        public override IRepository create_sut()
        {
            return resolve.dependency_for<IRepository>();
        }
    }
}