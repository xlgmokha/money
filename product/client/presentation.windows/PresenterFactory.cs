namespace presentation.windows
{
    public interface PresenterFactory
    {
        T create<T>() where T : Presenter;
    }
}