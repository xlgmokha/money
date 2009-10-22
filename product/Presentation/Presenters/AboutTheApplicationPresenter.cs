using MoMoney.Presentation.Core;
using momoney.presentation.views;

namespace momoney.presentation.presenters
{
    public interface IAboutApplicationPresenter : IContentPresenter
    {
    }

    public class AboutTheApplicationPresenter : ContentPresenter<IAboutApplicationView>, IAboutApplicationPresenter
    {
        public AboutTheApplicationPresenter(IAboutApplicationView view) : base(view)
        {
        }

        public override void run()
        {
        }
    }
}