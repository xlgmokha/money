using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Presenters
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