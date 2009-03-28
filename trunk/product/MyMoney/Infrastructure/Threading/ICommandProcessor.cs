using System;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Threading
{
    public interface ICommandProcessor : ICommand
    {
        void add(Action action_to_process);
        void add(ICommand command_to_process);
        void stop();
    }
}