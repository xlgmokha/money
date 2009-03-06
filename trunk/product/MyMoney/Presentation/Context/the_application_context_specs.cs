using System;
using System.Windows.Forms;
using jpboodhoo.bdd.contexts;
using MoMoney.Presentation.Model.Menu.File.Commands;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;
using Rhino.Mocks;

namespace MoMoney.Presentation.Context
{
    [Concern(typeof (the_application_context))]
    public abstract class behaves_like_an_application_context : concerns_for<ApplicationContext, the_application_context>
    {
        public override ApplicationContext create_sut()
        {
            return new the_application_context(shell_view, exit_command, load_application);
        }

        context c = () =>
                        {
                            shell_view = dependency<ApplicationShell>();
                            exit_command = an<IExitCommand>();
                            load_application = an<ILoadApplicationShellCommand>();
                        };

        static protected ApplicationShell shell_view;
        static protected IExitCommand exit_command;
        static protected ILoadApplicationShellCommand load_application;
    }

    public class when_starting_the_application : behaves_like_an_application_context
    {
        it should_specify_the_main_shell_view_as_the_main_form = () => result.should_be_equal_to(shell_view);

        it should_run_the_main_shell_presenter = () => load_application.was_told_to(x => x.run());

        because b = () => { result = sut.MainForm; };

        static Form result;
    }

    public class when_the_application_shell_is_closed : behaves_like_an_application_context
    {
        it should_shut_the_application_down = () => exit_command.was_told_to(x => x.run());

        because b = () => shell_view.Raise(x => x.Closed += null, shell_view, EventArgs.Empty);
    }
}