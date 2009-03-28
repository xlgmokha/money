using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views.core;
using MoMoney.Presentation.Views.Menu.Help;

namespace MoMoney.Presentation.Presenters.Menu.Help
{
    public interface IAboutApplicationPresenter : IContentPresenter
    {
    }

    public class AboutTheApplicationPresenter : IAboutApplicationPresenter
    {
        readonly IAboutApplicationView view;

        public AboutTheApplicationPresenter(IAboutApplicationView view)
        {
            this.view = view;
        }

        public void run()
        {
            view.display();
        }

        IDockedContentView IContentPresenter.View
        {
            get { return view; }
        }
    }
}