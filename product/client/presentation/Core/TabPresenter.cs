using System;
using developwithpassion.bdd.core.extensions;
using momoney.presentation.views;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Core
{
    public abstract class TabPresenter<Tab> : IContentPresenter where Tab : ITab
    {
        protected readonly Tab view;
        Guid id = Guid.NewGuid();

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
            return "{0} {1}".format_using(id, GetType().Name);
        }
    }
}