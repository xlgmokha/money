using MoMoney.Infrastructure.Extensions;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Core
{
    public abstract class ContentPresenter<T> : IContentPresenter where T : IDockedContentView
    {
        protected readonly T view;

        protected ContentPresenter(T view)
        {
            this.view = view;
        }

        IDockedContentView IContentPresenter.View
        {
            get { return view; }
        }

        public abstract void run();

        public virtual void activate()
        {
            this.log().debug("activated: {0}", this);
        }

        public virtual void deactivate()
        {
            this.log().debug("deactivated: {0}", this);
        }

        public virtual bool can_close()
        {
            return true;
        }
    }
}