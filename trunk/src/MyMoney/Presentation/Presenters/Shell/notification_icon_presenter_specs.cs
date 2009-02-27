using jpboodhoo.bdd.contexts;
using MyMoney.Infrastructure.eventing;
using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Presenters.Shell
{
    [Concern(typeof (notification_icon_presenter))]
    public abstract class behaves_like_notification_icon_presenter : concerns_for<INotificationIconPresenter, notification_icon_presenter>
    {
        public override INotificationIconPresenter create_sut()
        {
            return new notification_icon_presenter(view, broker);
        }

        context c = () =>
                        {
                            view = the_dependency<INotificationIconView>();
                            broker = the_dependency<IEventAggregator>();
                        };

        protected static INotificationIconView view;
        protected static IEventAggregator broker;
    }

    public class when_initializing_the_notification_icon : behaves_like_notification_icon_presenter
    {
        it should_ask_the_view_to_display_the_correct_icon_and_text = () => view.was_told_to(v => v.display(ApplicationIcons.Application, "mokhan.ca"));

        because b = () => sut.run();
    }
}