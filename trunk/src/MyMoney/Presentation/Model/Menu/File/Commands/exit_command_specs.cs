using jpboodhoo.bdd.contexts;
using MyMoney.Infrastructure.eventing;
using MyMoney.Infrastructure.System;
using MyMoney.Presentation.Model.messages;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;

namespace MyMoney.Presentation.Model.Menu.File.Commands
{
    [Concern(typeof (exit_command))]
    public class when_closing_the_application : concerns_for<IExitCommand, exit_command>
    {
        it should_ask_the_application_environment_to_shut_down = () => application.was_told_to(x => x.ShutDown());

        it should_publish_the_shut_down_event = () => broker.was_told_to(x => x.publish<closing_the_application>());

        context c = () =>
                        {
                            application = an<IApplicationEnvironment>();
                            broker = an<IEventAggregator>();
                        };

        public override IExitCommand create_sut()
        {
            return new exit_command(application, broker);
        }

        because b = () => sut.run();

        static IApplicationEnvironment application;
        static IEventAggregator broker;
    }
}