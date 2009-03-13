using System;
using developwithpassion.bdd.contexts;
using MoMoney.Presentation.Model.Menu.File.Commands;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Views.Shell
{
    public class behaves_like_application_shell : concerns_for<IShell, ApplicationShell>
    {
    }

    //public class when_the_application_shell_is_closed : behaves_like_application_shell
    //{
    //    it should_execute_the_close_command = () => close_command.was_told_to(x => x.run());

    //    context c = () => { close_command = the_dependency<ICloseCommand>(); };

    //    because b = () => EventTrigger.trigger_event<Events.FormEvents>(x => x.OnClosed(new EventArgs()), sut);

    //    static ICloseCommand close_command;
    //}
}