using Gorilla.Commons.Utility;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.Service.Contracts.Infrastructure.Updating
{
    public interface IDownloadTheLatestVersion : ICallbackCommand<Percent>
    {
    }
}