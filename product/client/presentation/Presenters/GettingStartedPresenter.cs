using MoMoney.Presentation.Core;
using momoney.presentation.views;

namespace momoney.presentation.presenters
{
    public class GettingStartedPresenter : ContentPresenter<IGettingStartedView>
    {
        public GettingStartedPresenter(IGettingStartedView view) : base(view)
        {
        }
    }
}