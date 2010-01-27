using System.Collections.Generic;
using gorilla.commons.utility;
using MoMoney.Presentation.Core;
using momoney.presentation.presenters;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Presenters
{
    public class MainMenuPresenter : TabPresenter<IMainMenuView>
    {
        IRunPresenterCommand command;

        public MainMenuPresenter(IMainMenuView view, IRunPresenterCommand command) : base(view)
        {
            this.command = command;
        }

        protected override void present()
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