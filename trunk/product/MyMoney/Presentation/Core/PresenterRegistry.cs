using System.Collections.Generic;
using MoMoney.Domain.Core;

namespace MoMoney.Presentation.Core
{
    public interface IPresenterRegistry : IRegistry<IPresenter>
    {
    }

    public class PresenterRegistry : IPresenterRegistry
    {
        readonly IRegistry<IPresenter> presenters;

        public PresenterRegistry(IRegistry<IPresenter> presenters)
        {
            this.presenters = presenters;
        }

        public IEnumerable<IPresenter> all()
        {
            return presenters.all();
        }
    }
}