using MbUnit.Framework;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Container;
using MoMoney.Testing.MetaData;

namespace MoMoney.Testing.spechelpers.contexts
{
    [run_in_real_container]
    [Concern(typeof (IRepository))]
    [Ignore]
    public abstract class behaves_like_a_repository : concerns_for<IRepository>
    {
        public override IRepository create_sut()
        {
            return resolve.dependency_for<IRepository>();
        }
    }
}