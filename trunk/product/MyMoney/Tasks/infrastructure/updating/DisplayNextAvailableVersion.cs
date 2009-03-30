using MoMoney.Infrastructure.Threading;
using MoMoney.Presentation.Model.updates;
using MoMoney.Tasks.infrastructure.core;
using MoMoney.Utility.Core;

namespace MoMoney.Tasks.infrastructure.updating
{
    public interface IDisplayNextAvailableVersion : ICallbackCommand<ApplicationVersion>
    {
    }

    public class DisplayNextAvailableVersion : IDisplayNextAvailableVersion
    {
        readonly IWhatIsTheAvailableVersion query;
        readonly ICommandProcessor processor;
        readonly ICommandFactory factory;

        public DisplayNextAvailableVersion(IWhatIsTheAvailableVersion query, ICommandProcessor processor,
                                           ICommandFactory factory)
        {
            this.query = query;
            this.factory = factory;
            this.processor = processor;
        }

        public void run(ICallback<ApplicationVersion> item)
        {
            processor.add(factory.create_for(item, query));
        }
    }
}