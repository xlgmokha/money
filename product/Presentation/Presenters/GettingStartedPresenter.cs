using MoMoney.Presentation.Core;
using momoney.presentation.views;

namespace momoney.presentation.presenters
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