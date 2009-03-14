using developwithpassion.bdd.contexts;
using MbUnit.Framework;
using MoMoney.Domain.Core;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Testing.MetaData;

namespace MoMoney.Testing.spechelpers.contexts
{
    //[run_in_real_container]
    [Concern(typeof (IRepository))]
    [Ignore]
    public abstract class behaves_like_a_repository : concerns_for<IRepository>
    {
        public override IRepository create_sut()
        {
            return resolve.dependency_for<IRepository>();
        }

        before_all_observations all = () => resolve.initialize_with(new WindsorDependencyRegistry());

        after_all_observations after_all = () => resolve.initialize_with(null);
    }
}