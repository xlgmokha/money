using System.Collections.Generic;
using MyMoney.Infrastructure.Threading;
using MyMoney.Utility.Core;

namespace MyMoney.Utility.Extensions
{
    public static class command_extensions
    {
        public static ICommand then<Command>(this ICommand left) where Command : ICommand, new()
        {
            return then(left, new Command());
        }

        public static ICommand then(this ICommand left, ICommand right)
        {
            return new chained_command(left, right);
        }

        public static ICommand as_command_chain(this IEnumerable<ICommand> commands)
        {
            var processor = new CommandProcessor();
            commands.each(processor.add);
            return processor;
        }
    }
}