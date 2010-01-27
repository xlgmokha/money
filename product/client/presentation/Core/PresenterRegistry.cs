using System.Collections;
using System.Collections.Generic;
using gorilla.commons.utility;

namespace MoMoney.Presentation.Core
{
    public interface IPresenterRegistry : Registry<Presenter> {}

    public class PresenterRegistry : IPresenterRegistry
    {
        readonly Registry<Presenter> presenters;

        public PresenterRegistry(Registry<Presenter> presenters)
        {
            this.presenters = presenters;
        }

        public IEnumerable<Presenter> all()
        {
            return presenters.all();
        }

        public IEnumerator<Presenter> GetEnumerator()
        {
            return all().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}