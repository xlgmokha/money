using System;
using gorilla.commons.utility;

namespace gorilla.commons.infrastructure.threading
{
    public interface CommandProcessor : Command
    {
        void add(Action command);
        void add(Command command_to_process);
        void stop();
    }
}