using System;
using System.Linq;
using Gorilla.Commons.Infrastructure.Logging;
using gorilla.commons.utility;
using momoney.presentation.views;

namespace MoMoney.Presentation.Core
{
    public class CachingViewFactory : ViewFactory
    {
        Registry<View> views;

        public CachingViewFactory(Registry<View> views)
        {
            this.views = views;
        }

        public View<Presenter> create_for<Presenter>() where Presenter : Core.Presenter
        {
            if (views.all().Any(x => typeof (View<Presenter>).IsAssignableFrom(x.GetType())))
            {
                return views.find_an_implementation_of<View, View<Presenter>>();
            }
            this.log().debug("cannot find a view for {0}", typeof (Presenter).Name);
            return Null<Presenter>.View;
        }

        class Null<T> : View<T> where T : Presenter
        {
            static public readonly View<T> View = new Null<T>();

            public void attach_to(T presenter) {}

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

            public void Dispose() {}

            public override string ToString()
            {
                return typeof (Null<T>).ToString();
            }
        }
    }
}