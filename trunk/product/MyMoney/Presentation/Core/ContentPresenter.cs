using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Core
{
    public abstract class ContentPresenter<T> : IContentPresenter where T : IDockedContentView
    {
        protected ContentPresenter(T view)
        {
            View = view;
        }

        public abstract void run();
        public IDockedContentView View { get; set; }
    }
}