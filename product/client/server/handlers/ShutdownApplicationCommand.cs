using System;
using Gorilla.Commons.Infrastructure.Logging;
using presentation.windows.common;
using presentation.windows.common.messages;

namespace presentation.windows.server.handlers
{
    public class ShutdownApplicationCommand : AbstractHandler<ApplicationShuttingDown>
    {
        public override void handle(ApplicationShuttingDown item)
        {
            this.log().debug("shutting down");
            Environment.Exit(Environment.ExitCode);
        }
    }
}