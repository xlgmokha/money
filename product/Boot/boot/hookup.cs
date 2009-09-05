using Gorilla.Commons.Utility.Core;

namespace MoMoney.windows.ui
{
    class hookup
    {
        static public Command the<Command>() where Command : ICommand, new()
        {
            return new Command();
        }
    }
}