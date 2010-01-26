using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;
using momoney.presentation.views;

namespace MoMoney.Presentation.Core
{
    public interface ViewFactory
    {
        IView<Presenter> create_for<Presenter>() where Presenter : IPresenter;
    }

    public class CachingViewFactory : ViewFactory
    {
        Registry<IView> views;

        public CachingViewFactory(Registry<IView> views)
        {
            this.views = views;
        }

        public IView<Presenter> create_for<Presenter>() where Presenter : IPresenter
        {
            views.each(x => this.log().debug("registered view: {0}", x));
            this.log().debug("creating a view for {0}", typeof (Presenter));
            return views.find_an_implementation_of<IView, IView<Presenter>>();
        }
    }
}