using MoMoney.Presentation.Core;
using momoney.presentation.views;

namespace momoney.presentation.presenters
{
    public class GettingStartedPresenter : ContentPresenter<IGettingStartedView>
    {
        public GettingStartedPresenter(IGettingStartedView view) : base(view)
        {
        }

        public override void present()
        {
            view.attach_to(this);
        }
    }
}