using System;
using gorilla.commons.utility;

namespace MoMoney.Service.Infrastructure.Threading
{
    public interface CommandProcessor : Command
    {
        void add(Action command);
        void add(Command command_to_process);
        void stop();
    }
}