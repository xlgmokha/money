using System;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using momoney.presentation.presenters;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Winforms.Helpers;

namespace MoMoney.Presentation.Winforms.Views
{
    public class behaves_like_application_shell : concerns_for<IShell, ApplicationShell>
    {
    }

    public class when_the_application_shell_is_closed : behaves_like_application_shell
    {
        it should_execute_the_close_command = () => presenter.was_told_to(x => x.shut_down());

        context c = () => { presenter = an<IApplicationShellPresenter>(); };

        after_the_sut_has_been_created a = () => { sut.attach_to(presenter); };

        because b = () => EventTrigger.trigger_event<Events.FormEvents>(x => x.OnClosed(new EventArgs()), sut);

        static IApplicationShellPresenter presenter;
    }
}