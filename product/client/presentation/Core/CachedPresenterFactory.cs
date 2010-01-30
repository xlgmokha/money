using gorilla.commons.utility;

namespace MoMoney.Presentation.Core
{
    public class CachedPresenterFactory : PresenterFactory
    {
        Registry<Presenter> presenters;
        ViewFactory view_factory;

        public CachedPresenterFactory(Registry<Presenter> presenters, ViewFactory view_factory)
        {
            this.presenters = presenters;
            this.view_factory = view_factory;
        }

        public TPresenter create<TPresenter>() where TPresenter : Presenter
        {
            var presenter = presenters.find_an_implementation_of<Presenter, TPresenter>();
            var view = view_factory.create_for<TPresenter>();
            view.attach_to(presenter);
            return presenter;
        }
    }
}