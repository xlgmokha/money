using Gorilla.Commons.Infrastructure.Reflection;
using gorilla.commons.utility;

namespace MoMoney.boot.container.registration
{
    public interface IStartupCommand : ArgCommand<Assembly> {}
}