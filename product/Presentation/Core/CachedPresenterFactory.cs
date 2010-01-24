using gorilla.commons.utility;

namespace MoMoney.Presentation.Core
{
    public interface PresenterFactory
    {
        Presenter create<Presenter>() where Presenter : IPresenter;
    }

    public class CachedPresenterFactory : PresenterFactory
    {
        readonly IPresenterRegistry registered_presenters;

        public CachedPresenterFactory(IPresenterRegistry registered_presenters)
        {
            this.registered_presenters = registered_presenters;
        }

        public Presenter create<Presenter>() where Presenter : IPresenter
        {
            return registered_presenters.find_an_implementation_of<IPresenter, Presenter>();
        }
    }
}