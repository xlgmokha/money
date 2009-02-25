using System.Collections.Generic;
using MyMoney.Domain.Core;

namespace MyMoney.Presentation.Core
{
    public interface IPresenterRegistry : IRegistry<IPresenter>
    {
    }

    public class presenter_registry : IPresenterRegistry
    {
        readonly IRegistry<IPresenter> presenters;

        public presenter_registry(IRegistry<IPresenter> presenters)
        {
            this.presenters = presenters;
        }

        public IEnumerable<IPresenter> all()
        {
            return presenters.all();
        }
    }
}