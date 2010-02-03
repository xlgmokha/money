using gorilla.commons.utility;

namespace MoMoney.Presentation.Core
{
    public class CachedPresenterFactory : PresenterFactory
    {
        Registry<Presenter> presenters;

        public CachedPresenterFactory(Registry<Presenter> presenters)
        {
            this.presenters = presenters;
        }

        public TPresenter create<TPresenter>() where TPresenter : Presenter
        {
            return presenters.find_an_implementation_of<Presenter, TPresenter>();
        }
    }
}