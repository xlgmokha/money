using developwithpassion.bdd.contexts;
using MoMoney.DataAccess.core;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Testing.MetaData;
using MoMoney.windows.ui;

namespace MoMoney.Testing.spechelpers.contexts
{
    //[run_in_real_container]
    [Concern(typeof (IDatabaseGateway))]
    public abstract class behaves_like_a_repository : concerns_for<IDatabaseGateway>
    {
        public override IDatabaseGateway create_sut()
        {
            return resolve.dependency_for<IDatabaseGateway>();
        }

        before_all_observations all = () => get_the.registry(null);

        after_all_observations after_all = () => resolve.initialize_with(null);
    }
}