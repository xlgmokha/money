using momoney.presentation.views;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Core
{
    public abstract class TabPresenter<Tab> : IContentPresenter where Tab : IDockedContentView
    {
        protected readonly Tab view;

        protected TabPresenter(Tab view)
        {
            this.view = view;
        }

        protected virtual void present() {}

        public void present(Shell shell)
        {
            shell.add(view);
            present();
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}