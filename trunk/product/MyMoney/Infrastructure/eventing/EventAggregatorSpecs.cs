using developwithpassion.bdd.contexts;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;
using Rhino.Mocks;

namespace MoMoney.Infrastructure.eventing
{
    public class behaves_like_event_aggregator : concerns_for<IEventAggregator, EventAggregator>
    {
    }

    public class when_a_event_is_raised_in_the_system : behaves_like_event_aggregator
    {
        it should_notify_all_subscribers_of_the_event = () =>
                                                            {
                                                                first_subscriber.was_told_to(x => x.notify(message));
                                                                second_subscriber.was_told_to(x => x.notify(message));
                                                            };

        it should_not_notify_any_subscribers_that_subscribed_to_a_different_event =
            () => incorrect_subscriber.was_not_told_to(x => x.notify(Arg<AnotherEvent>.Is.Anything));

        context c = () =>
                        {
                            message = new TestEvent();
                            first_subscriber = an<IEventSubscriber<TestEvent>>();
                            second_subscriber = an<IEventSubscriber<TestEvent>>();
                            incorrect_subscriber = an<IEventSubscriber<AnotherEvent>>();
                        };

        because b = () =>
                        {
                            sut.subscribe_to(first_subscriber);
                            sut.subscribe(second_subscriber);
                            sut.publish(message);
                        };

        static TestEvent message;
        static IEventSubscriber<TestEvent> first_subscriber;
        static IEventSubscriber<TestEvent> second_subscriber;
        static IEventSubscriber<AnotherEvent> incorrect_subscriber;
    }

    public class TestEvent : IEvent
    {
    }

    public class AnotherEvent : IEvent
    {
    }
}