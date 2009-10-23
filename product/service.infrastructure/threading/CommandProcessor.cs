using System;
using System.Linq.Expressions;
using gorilla.commons.utility;

namespace MoMoney.Service.Infrastructure.Threading
{
    public interface CommandProcessor : Command
    {
        void add(Expression<Action> action_to_process);
        void add(Command command_to_process);
        void stop();
    }
}