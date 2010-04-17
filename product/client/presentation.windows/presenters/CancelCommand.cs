namespace presentation.windows.presenters
{
    public class CancelCommand : UICommand<DialogPresenter>
    {
        protected override void run(DialogPresenter presenter)
        {
            presenter.close();
        }
    }
}