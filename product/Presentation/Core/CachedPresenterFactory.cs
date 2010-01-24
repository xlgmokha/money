using gorilla.commons.utility;

namespace MoMoney.Presentation.Core
{
    public interface PresenterFactory
    {
        Presenter create<Presenter>() where Presenter : IPresenter;
    }

    public class CachedPresenterFactory : PresenterFactory
    {
        IPresenterRegistry registered_presenters;
        ViewFactory view_factory;

        public CachedPresenterFactory(IPresenterRegistry registered_presenters, ViewFactory view_factory)
        {
            this.registered_presenters = registered_presenters;
            this.view_factory = view_factory;
        }

        public Presenter create<Presenter>() where Presenter : IPresenter
        {
            var presenter = registered_presenters.find_an_implementation_of<IPresenter, Presenter>();
            view_factory.create_for<Presenter>().attach_to(presenter);
            return presenter;
        }
    }
}