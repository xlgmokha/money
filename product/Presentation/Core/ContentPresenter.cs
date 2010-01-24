using momoney.presentation.views;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Core
{
    public abstract class ContentPresenter<T> : IContentPresenter where T : IDockedContentView
    {
        protected readonly T view;

        protected ContentPresenter(T view)
        {
            this.view = view;
        }

        protected virtual void present()
        {
        }

        public void present(IShell shell)
        {
            shell.add(view);
            present();
        }
    }
}