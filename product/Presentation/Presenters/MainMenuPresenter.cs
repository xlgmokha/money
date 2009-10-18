using System.Collections.Generic;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Presenters
{
    public interface IMainMenuPresenter : IContentPresenter
    {
    }

    public class MainMenuPresenter : ContentPresenter<IMainMenuView>, IMainMenuPresenter
    {
        IRunPresenterCommand command;

        public MainMenuPresenter(IMainMenuView view, IRunPresenterCommand command) : base(view)
        {
            this.command = command;
        }

        public override void run()
        {
            all_factories().each(x => view.add(x));
        }

        IEnumerable<IActionTaskPaneFactory> all_factories()
        {
            yield return new AddCompanyTaskPane(command);
            yield return new AddIncomeTaskPane(command);
            yield return new AddBillingTaskPane(command);
            yield return new AddReportingTaskPane(command);
        }
    }
}