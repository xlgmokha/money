using MoMoney.Presentation.Core;
using momoney.presentation.views;

namespace momoney.presentation.presenters
{
    public class AboutTheApplicationPresenter : TabPresenter<IAboutApplicationView>
    {
        public AboutTheApplicationPresenter(IAboutApplicationView view) : base(view)
        {
        }
    }
}