using gorilla.commons.utility;
using MoMoney.DTO;

namespace MoMoney.Service.Contracts.Infrastructure.Updating
{
    public interface IWhatIsTheAvailableVersion : Query<ApplicationVersion>
    {
    }
}