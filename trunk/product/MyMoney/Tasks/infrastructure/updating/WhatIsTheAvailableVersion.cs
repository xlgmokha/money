using MoMoney.Presentation.Model.updates;
using MoMoney.Utility.Core;

namespace MoMoney.Tasks.infrastructure.updating
{
    public interface IWhatIsTheAvailableVersion : IQuery<ApplicationVersion>
    {
    }

    public class WhatIsTheAvailableVersion : IWhatIsTheAvailableVersion
    {
        readonly IUpdateTasks tasks;

        public WhatIsTheAvailableVersion(IUpdateTasks tasks)
        {
            this.tasks = tasks;
        }

        public ApplicationVersion fetch()
        {
            return tasks.current_application_version();
        }
    }
}