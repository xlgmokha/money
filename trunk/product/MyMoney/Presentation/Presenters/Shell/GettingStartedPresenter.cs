using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views.core;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface IGettingStartedPresenter : IContentPresenter
    {
    }

    public class GettingStartedPresenter : IGettingStartedPresenter
    {
        readonly IGettingStartedView view;

        public GettingStartedPresenter(IGettingStartedView view)
        {
            this.view = view;
        }

        public void run()
        {
            view.display();
        }

        public IDockedContentView View
        {
            get { return view; }
        }
    }
}