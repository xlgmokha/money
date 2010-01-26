using System.Collections;
using System.Collections.Generic;
using gorilla.commons.utility;

namespace MoMoney.Presentation.Core
{
    public interface IPresenterRegistry : Registry<IPresenter> {}

    public class PresenterRegistry : IPresenterRegistry
    {
        readonly Registry<IPresenter> presenters;

        public PresenterRegistry(Registry<IPresenter> presenters)
        {
            this.presenters = presenters;
        }

        public IEnumerable<IPresenter> all()
        {
            return presenters.all();
        }

        public IEnumerator<IPresenter> GetEnumerator()
        {
            return all().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}