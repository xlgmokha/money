using System.Threading;
using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;
using presentation.windows.commands.dto;

namespace presentation.windows.commands
{
    public class AddFamilyMember : ArgCommand<FamilyMemberToAdd>
    {
        public void run_against(FamilyMemberToAdd item)
        {
            this.log().debug("adding family member");
            Thread.Sleep(5000);
        }
    }
}