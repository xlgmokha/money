using System.Threading;
using gorilla.commons.utility;
using presentation.windows.commands.dto;

namespace presentation.windows.commands
{
    public class AddFamilyMember : ArgCommand<FamilyMemberToAdd>
    {
        public void run_against(FamilyMemberToAdd item)
        {
            Thread.Sleep(5000);
        }
    }
}