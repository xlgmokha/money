using System.Windows.Input;

namespace presentation.windows
{
    public interface IObservableCommand : ICommand
    {
        void notify_observers();
    }
}