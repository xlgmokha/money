using System.Data;
using System.Threading;
using MoMoney.Service.Infrastructure.Eventing;
using Rhino.Mocks;

namespace tests.unit.client.service.infrastructure.eventing
{
    public abstract class behaves_like_event_aggregator : TestsFor<EventAggregator>
    {
        public override EventAggregator create_sut()
        {
            return new SynchronizedEventAggregator(new SynchronizationContext());
        }
    }

    [Concern(typeof (SynchronizedEventAggregator))]
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
            first_subscriber = an<EventSubscriber<TestEvent>>();
            second_subscriber = an<EventSubscriber<TestEvent>>();
            incorrect_subscriber = an<EventSubscriber<AnotherEvent>>();
        };

        because b = () =>
        {
            sut.subscribe_to(first_subscriber);
            sut.subscribe(second_subscriber);
            sut.publish(message);
        };

        static TestEvent message;
        static EventSubscriber<TestEvent> first_subscriber;
        static EventSubscriber<TestEvent> second_subscriber;
        static EventSubscriber<AnotherEvent> incorrect_subscriber;
    }

    [Concern(typeof (SynchronizedEventAggregator))]
    public class when_publishing_a_call_to_all_subscribers : behaves_like_event_aggregator
    {
        it should_make_the_call_on_each_subscriber = () => connection.was_told_to(x => x.ChangeDatabase("localhost"));

        context c = () =>
        {
            connection = an<IDbConnection>();
            command = an<IDbCommand>();
        };

        because b = () =>
        {
            sut.subscribe(connection);
            sut.subscribe(command);
            sut.publish<IDbConnection>(x => x.ChangeDatabase("localhost"));
        };

        static IDbConnection connection;
        static IDbCommand command;
    }

    public class TestEvent : IEvent {}

    public class AnotherEvent : IEvent {}
}