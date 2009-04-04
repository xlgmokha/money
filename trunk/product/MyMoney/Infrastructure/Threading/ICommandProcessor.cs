using System;
using System.Linq.Expressions;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Threading
{
    public interface ICommandProcessor : ICommand
    {
        void add(Expression<Action> action_to_process);
        void add(ICommand command_to_process);
        void stop();
    }
}