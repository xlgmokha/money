using gorilla.commons.utility;

namespace MoMoney.Presentation.Core
{
    public class CachedPresenterFactory : PresenterFactory
    {
        IPresenterRegistry presenters;
        ViewFactory view_factory;

        public CachedPresenterFactory(IPresenterRegistry presenters, ViewFactory view_factory)
        {
            this.presenters = presenters;
            this.view_factory = view_factory;
        }

        public TPresenter create<TPresenter>() where TPresenter : Presenter
        {
            var presenter = presenters.find_an_implementation_of<Presenter, TPresenter>();
            view_factory
                .create_for<TPresenter>()
                .attach_to(presenter);
            return presenter;
        }
    }
}