using MoMoney.Presentation.Views.Core;

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
        }

        public virtual void deactivate()
        {
        }

        public virtual bool can_close()
        {
            return true;
        }
    }
}