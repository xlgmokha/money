using Gorilla.Commons.Utility.Core;

namespace MoMoney.Presentation.Views
{
    public interface IDialogLauncher
    {
        void launch<Command>(Command command) where Command : ICommand;
    }
}