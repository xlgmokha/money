using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Views.core
{
    public interface ICommandDialog<Command> where Command : ICommand
    {
    }

    public interface IDialogLauncher
    {
        void launch<Command>(Command command) where Command : ICommand;
    }
}