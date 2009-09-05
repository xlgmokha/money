using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface IGettingStartedPresenter : IContentPresenter
    {
    }

    public class GettingStartedPresenter : ContentPresenter<IGettingStartedView>, IGettingStartedPresenter
    {
        public GettingStartedPresenter(IGettingStartedView view) : base(view)
        {
        }

        public override void run()
        {
            view.attach_to(this);
        }
    }
}