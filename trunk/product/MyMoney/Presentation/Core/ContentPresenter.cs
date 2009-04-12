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

        public abstract void run();

        IDockedContentView IContentPresenter.View
        {
            get { return view; }
        }
    }
}