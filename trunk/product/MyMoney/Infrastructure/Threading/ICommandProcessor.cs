using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Threading
{
    public interface ICommandProcessor : ICommand
    {
        void add(ICommand command_to_process);
    }
}