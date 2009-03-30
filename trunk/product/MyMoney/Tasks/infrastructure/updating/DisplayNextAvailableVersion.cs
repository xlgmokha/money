using MoMoney.Infrastructure.Threading;
using MoMoney.Presentation.Model.updates;
using MoMoney.Utility.Core;

namespace MoMoney.Tasks.infrastructure.updating
{
    public interface IDisplayNextAvailableVersion : IParameterizedCommand<ICallback<ApplicationVersion>>
    {
    }

    public class DisplayNextAvailableVersion : IDisplayNextAvailableVersion
    {
        readonly IWhatIsTheAvailableVersion query;
        readonly ICommandProcessor processor;

        public DisplayNextAvailableVersion(IWhatIsTheAvailableVersion query, ICommandProcessor processor)
        {
            this.query = query;
            this.processor = processor;
        }

        public void run(ICallback<ApplicationVersion> item)
        {
            processor.add(new RunQueryCommand<ApplicationVersion>(item, new ProcessQueryCommand<ApplicationVersion>(query)));
        }
    }
}