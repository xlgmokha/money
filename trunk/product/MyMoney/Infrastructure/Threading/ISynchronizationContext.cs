using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Threading
{
    public interface ISynchronizationContext : IParameterizedCommand<ICommand>
    {
    }
}