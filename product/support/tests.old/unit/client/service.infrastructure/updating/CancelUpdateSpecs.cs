using MoMoney.Service.Infrastructure.Updating;

namespace tests.unit.client.service.infrastructure.updating
{
    public class CancelUpdateSpecs
    {
        [Concern(typeof (CancelUpdate))]
        public class when_cancelling_an_update_of_the_application : runner<CancelUpdate>
        {
            it should_stop_downloading_the_update = () => deployment.was_told_to(x => x.UpdateAsyncCancel());

            context c = () =>
            {
                deployment = dependency<IDeployment>();
            };

            because b = () => sut.run();

            static IDeployment deployment;
        }
    }
}