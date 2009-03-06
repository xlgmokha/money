using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views.Menu.Help;

namespace MoMoney.Presentation.Presenters.Menu.Help
{
    public interface IAboutApplicationPresenter : IPresenter
    {
    }

    public class about_the_application_presenter : IAboutApplicationPresenter
    {
        private readonly IAboutApplicationView view;

        public about_the_application_presenter(IAboutApplicationView view)
        {
            this.view = view;
        }

        public void run()
        {
            view.display();
        }
    }
}