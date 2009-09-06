using System;
using System.Linq.Expressions;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.Service.Infrastructure.Threading
{
    public interface ICommandProcessor : ICommand
    {
        void add(Expression<Action> action_to_process);
        void add(ICommand command_to_process);
        void stop();
    }
}