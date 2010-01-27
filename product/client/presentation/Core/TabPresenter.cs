using momoney.presentation.views;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Core
{
    public abstract class TabPresenter<T> : IContentPresenter where T : IDockedContentView
    {
        protected readonly T view;

        protected TabPresenter(T view)
        {
            this.view = view;
        }

        protected virtual void present()
        {
        }

        public void present(Shell shell)
        {
            shell.add(view);
            present();
        }
    }
}