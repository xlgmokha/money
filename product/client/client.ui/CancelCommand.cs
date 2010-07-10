namespace presentation.windows
{
    public class CancelCommand : UICommand<DialogPresenter>
    {
        protected override void run(DialogPresenter presenter)
        {
            presenter.close();
        }
    }
}