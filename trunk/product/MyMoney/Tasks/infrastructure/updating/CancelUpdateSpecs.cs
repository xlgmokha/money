using System.Deployment.Application;
using developwithpassion.bdd.contexts;
using MbUnit.Framework;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Tasks.infrastructure.updating
{
    public class CancelUpdateSpecs
    {
    }

    [Ignore("cant mock ApplicationDeployment")]
    public class when_cancelling_an_update_of_the_application : concerns_for<ICancelUpdate, CancelUpdate>
    {
        it should_stop_downloading_the_update = () => deployment.was_told_to(x => x.UpdateAsyncCancel());

        context c = () => { deployment = the_dependency<ApplicationDeployment>(); };

        because b = () => sut.run();

        static ApplicationDeployment deployment;
    }
}