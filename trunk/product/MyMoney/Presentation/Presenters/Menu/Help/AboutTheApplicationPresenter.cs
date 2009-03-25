using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views.Menu.Help;

namespace MoMoney.Presentation.Presenters.Menu.Help
{
    public interface IAboutApplicationPresenter : IPresenter
    {
    }

    public class AboutTheApplicationPresenter : IAboutApplicationPresenter
    {
        private readonly IAboutApplicationView view;

        public AboutTheApplicationPresenter(IAboutApplicationView view)
        {
            this.view = view;
        }

        public void run()
        {
            view.display();
        }
    }
}