using System.Windows.Input;

namespace presentation.windows.presenters
{
    public interface IObservableCommand : ICommand
    {
        void notify_observers();
    }
}