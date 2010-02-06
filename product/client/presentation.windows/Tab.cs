namespace presentation.windows
{
    public interface Tab<Presenter> : View<Presenter> where Presenter : TabPresenter {}
}