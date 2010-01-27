using gorilla.commons.infrastructure.thirdparty;
using gorilla.commons.utility;

namespace MoMoney.boot.container.registration
{
    public interface IContainerStartup : ParameterizedCommand<DependencyRegistration> { }
}