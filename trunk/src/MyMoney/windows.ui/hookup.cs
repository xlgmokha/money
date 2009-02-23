using MyMoney.Utility.Core;

namespace MyMoney.windows.ui
{
    internal class hookup
    {
        public static Command the<Command>() where Command : ICommand, new()
        {
            return new Command();
        }
    }
}