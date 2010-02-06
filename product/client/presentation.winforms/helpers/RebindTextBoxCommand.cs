using System;
using System.Linq.Expressions;

namespace MoMoney.Presentation.Winforms.Helpers
{
    public class RebindTextBoxCommand<T> : ITextBoxCommand<T>
    {
        readonly Expression<Func<string, T>> binder;

        public RebindTextBoxCommand(Expression<Func<string, T>> binder)
        {
            this.binder = binder;
        }

        public void run_against(IBindableTextBox<T> item)
        {
            item.bind_to(binder.Compile()(item.text()));
        }
    }
}