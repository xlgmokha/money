using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.Presentation.Core;
using momoney.presentation.model.eventing;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.model.menu.file
{
    [Concern(typeof (ExitCommand))]
    public abstract class behaves_like_exit_command : concerns_for<IExitCommand>
    {
        public override IExitCommand create_sut()
        {
            return new ExitCommand(application, broker, save_changes_command);
        }

        context c = () =>
        {
            application = the_dependency<IApplication>();
            broker = the_dependency<IEventAggregator>();
            save_changes_command = the_dependency<ISaveChangesCommand>();
        };

        protected static IApplication application;
        protected static IEventAggregator broker;
        protected static ISaveChangesCommand save_changes_command;
    }

    public class when_closing_the_application_after_saving_the_project : behaves_like_exit_command
    {
        it should_ask_the_application_environment_to_shut_down = () => application.was_told_to(x => x.shut_down());

        it should_publish_the_shut_down_event = () => broker.was_told_to(x => x.publish<ClosingTheApplication>());

        because b = () => sut.saved();
    }

    public class when_closing_the_application_after_declining_to_save_the_project : behaves_like_exit_command
    {
        it should_ask_the_application_environment_to_shut_down = () => application.was_told_to(x => x.shut_down());

        it should_publish_the_shut_down_event = () => broker.was_told_to(x => x.publish<ClosingTheApplication>());

        because b = () => sut.not_saved();
    }

    public class when_closing_the_application_after_clicking_cancel_when_prompted_to_save_changes :
        behaves_like_exit_command
    {
        it should_not_ask_the_application_environment_to_shut_down = () => application.was_told_to(x => x.shut_down());

        it should_not_publish_the_shut_down_event = () => broker.was_told_to(x => x.publish<ClosingTheApplication>());

        because b = () => sut.not_saved();
    }
}