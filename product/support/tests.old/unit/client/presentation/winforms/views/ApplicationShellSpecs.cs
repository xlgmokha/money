using System;
using momoney.presentation.presenters;
using MoMoney.Presentation.Winforms.Helpers;
using MoMoney.Presentation.Winforms.Views;

namespace tests.unit.client.presentation.winforms.views
{
    public class ApplicationShellSpecs
    {
        [Concern(typeof (ApplicationShell))]
        public class concern : runner<ApplicationShell> {}

        public class when_the_application_shell_is_closed : concern
        {
            it should_execute_the_close_command = () => presenter.was_told_to(x => x.shut_down());

            context c = () =>
            {
                presenter = an<ApplicationShellPresenter>();
            };

            after_the_sut_has_been_created a = () =>
            {
                sut.attach_to(presenter);
            };

            because b = () => EventTrigger.trigger_event<Events.FormEvents>(x => x.OnClosed(new EventArgs()), sut);

            static ApplicationShellPresenter presenter;
        }
    }
}