using jpboodhoo.bdd.contexts;
using MyMoney.Infrastructure.eventing;
using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;

namespace MyMoney.Presentation.Presenters.Shell
{
    [Concern(typeof (notification_icon_presenter))]
    public class when_initializing_the_notification_icon :
        concerns_for<INotificationIconPresenter, notification_icon_presenter>
    {
        it should_ask_the_view_to_display_the_correct_icon_and_text =
            () => view.was_told_to(v => v.display(ApplicationIcons.Application, "mokhan.ca"));

        context c = () =>
                        {
                            view = the_dependency<INotificationIconView>();
                            broker = the_dependency<IEventAggregator>();
                        };

        because b = () => sut.run();

        public override INotificationIconPresenter create_sut()
        {
            return new notification_icon_presenter(view, broker);
        }

        static INotificationIconView view;
        static IEventAggregator broker;
    }
}