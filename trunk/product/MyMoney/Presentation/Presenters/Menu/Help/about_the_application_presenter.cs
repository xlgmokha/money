using MyMoney.Presentation.Core;
using MyMoney.Presentation.Views.Menu.Help;

namespace MyMoney.Presentation.Presenters.Menu.Help
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