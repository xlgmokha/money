namespace presentation.windows.presenters
{
    public interface UICommandBuilder
    {
        IObservableCommand build<T>(Presenter presenter) where T : UICommand;
    }
}