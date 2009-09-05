using Gorilla.Commons.Utility.Core;
using MoMoney.DTO;

namespace MoMoney.Service.Contracts.Infrastructure.Updating
{
    public interface IWhatIsTheAvailableVersion : IQuery<ApplicationVersion>
    {
    }
}