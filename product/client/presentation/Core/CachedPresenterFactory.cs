using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;

namespace MoMoney.Presentation.Core
{
    public interface PresenterFactory
    {
        Presenter create<Presenter>() where Presenter : Core.Presenter;
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

        public Presenter create<Presenter>() where Presenter : Core.Presenter
        {
            var presenter = presenters.find_an_implementation_of<Core.Presenter, Presenter>();
            var view = view_factory.create_for<Presenter>();
            this.log().debug("attaching {0} to {1}", view, presenter);
            view.attach_to(presenter);
            return presenter;
        }
    }
}