using Gorilla.Commons.Infrastructure.Reflection;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.boot.container.registration
{
    public interface IStartupCommand : ICommand, IParameterizedCommand<IAssembly>
    {
    }
}