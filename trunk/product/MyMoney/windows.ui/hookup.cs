using MoMoney.Utility.Core;

namespace MoMoney.windows.ui
{
    internal class hookup
    {
        public static Command the<Command>() where Command : ICommand, new()
        {
            return new Command();
        }
    }
}