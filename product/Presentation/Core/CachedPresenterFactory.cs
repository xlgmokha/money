using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;

namespace MoMoney.Presentation.Core
{
    public interface PresenterFactory
    {
        Presenter create<Presenter>() where Presenter : IPresenter;
    }

    public class CachedPresenterFactory : PresenterFactory
    {
        IPresenterRegistry presenters;
        ViewFactory view_factory;

        public CachedPresenterFactory(IPresenterRegistry presenters, ViewFactory view_factory)
        {
            this.presenters = presenters;
            this.view_factory = view_factory;
        }

        public Presenter create<Presenter>() where Presenter : IPresenter
        {
            presenters.each(x => this.log().debug("registered presenter: {0}", x));
            this.log().debug("creating... {0}", typeof (Presenter));
            var presenter = presenters.find_an_implementation_of<IPresenter, Presenter>();
            view_factory.create_for<Presenter>().attach_to(presenter);
            return presenter;
        }
    }
}