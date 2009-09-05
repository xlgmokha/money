using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views.Menu;

namespace MoMoney.Presentation.Presenters.Menu.Help
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