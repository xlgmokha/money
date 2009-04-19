using Gorilla.Commons.Utility.Core;

namespace Gorilla.Commons.Windows.Forms
{
    public interface IDialogLauncher
    {
        void launch<Command>(Command command) where Command : ICommand;
    }
}