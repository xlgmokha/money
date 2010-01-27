using System;
using System.ComponentModel;
using System.Linq;
using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;
using momoney.presentation.views;

namespace MoMoney.Presentation.Core
{
    public interface ViewFactory
    {
        IView<Presenter> create_for<Presenter>() where Presenter : Core.Presenter;
    }

    public class CachingViewFactory : ViewFactory
    {
        Registry<IView> views;

        public CachingViewFactory(Registry<IView> views)
        {
            this.views = views;
        }

        public IView<Presenter> create_for<Presenter>() where Presenter : Core.Presenter
        {
            if (views.all().Any(x => typeof (IView<Presenter>).IsAssignableFrom(x.GetType())))
            {
                return views.find_an_implementation_of<IView, IView<Presenter>>();
            }
            this.log().debug("cannot find a view for {0}", typeof (Presenter));
            return Null<Presenter>.View;
        }

        class Null<T> : IView<T> where T : Presenter
        {
            static public readonly IView<T> View = new Null<T>();

            public void attach_to(T presenter)
            {
            }

            public ControlAction<EventArgs> activated { get; set; }

            public ControlAction<EventArgs> deactivated { get; set; }

            public ControlAction<EventArgs> closed { get; set; }

            public ControlAction<CancelEventArgs> closing { get; set; }

            public IAsyncResult BeginInvoke(Delegate method, object[] args)
            {
                return null;
            }

            public object EndInvoke(IAsyncResult result)
            {
                return new object();
            }

            public object Invoke(Delegate method, object[] args)
            {
                return new object();
            }

            public bool InvokeRequired { get; set; }

            public void Dispose()
            {
            }
        }
    }
}