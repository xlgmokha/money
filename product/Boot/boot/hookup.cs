using Gorilla.Commons.Utility.Core;

namespace MoMoney.boot
{
    class hookup
    {
        static public Command the<Command>() where Command : ICommand, new()
        {
            return new Command();
        }
    }
}