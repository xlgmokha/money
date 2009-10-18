using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.Service.Contracts.Infrastructure.Updating;

namespace MoMoney.Service.Infrastructure.Updating
{
    public class CancelUpdateSpecs
    {
    }

    public class when_cancelling_an_update_of_the_application : concerns_for<ICancelUpdate, CancelUpdate>
    {
        it should_stop_downloading_the_update = () => deployment.was_told_to(x => x.UpdateAsyncCancel());

        context c = () => { deployment = the_dependency<IDeployment>(); };

        because b = () => sut.run();

        static IDeployment deployment;
    }
}