using System;
using System.Timers;
using jpboodhoo.bdd.contexts;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using Rhino.Mocks;

namespace MyMoney.Infrastructure.Threading
{
    [Concern(typeof (interval_timer))]
    public abstract class behaves_like_an_interval_timer : concerns_for<ITimer, interval_timer>
    {
        public override ITimer create_sut()
        {
            return new interval_timer(factory);
        }

        context c = () => { factory = the_dependency<ITimerFactory>(); };

        protected static ITimerFactory factory;
    }

    public class when_starting_a_timer_for_a_new_client : behaves_like_an_interval_timer
    {
        static ITimerClient client;
        static Timer timer;

        it should_create_a_new_timer = () => factory.was_told_to(f => f.create_for(new TimeSpan(0, 10, 0)));

        it should_start_the_timer = () => timer.was_told_to(t => t.Start());

        context c = () =>
                        {
                            client = an<ITimerClient>();
                            timer = dependency<Timer>();

                            factory.is_told_to(f => f.create_for(new TimeSpan(0, 10, 0))).it_will_return(timer);
                        };

        because b = () => sut.start_notifying(client, new TimeSpan(0, 10, 0));
    }

    [Concern(typeof (interval_timer))]
    public class when_starting_a_timer_for_an_existing_client : old_context_specification<ITimer>
    {
        ITimerFactory factory;
        ITimerClient client;
        Timer first_timer;
        Timer second_timer;

        [Observation]
        public void should_stop_the_previously_started_timer()
        {
            first_timer.was_told_to(t => t.Stop());
            first_timer.was_told_to(t => t.Dispose());
        }

        [Observation]
        public void should_start_a_new_timer()
        {
            second_timer.was_told_to(t => t.Start());
        }

        protected override ITimer context()
        {
            factory = an<ITimerFactory>();
            client = an<ITimerClient>();
            first_timer = an<Timer>();
            second_timer = an<Timer>();

            factory.is_told_to(f => f.create_for(new TimeSpan(0, 1, 1))).Return(first_timer);
            factory.is_told_to(f => f.create_for(new TimeSpan(0, 2, 2))).Return(second_timer);

            return new interval_timer(factory);
        }

        protected override void because()
        {
            sut.start_notifying(client, new TimeSpan(0, 1, 1));
            sut.start_notifying(client, new TimeSpan(0, 2, 2));
        }
    }

    [Concern(typeof (interval_timer))]
    public class when_a_timer_elapses : old_context_specification<ITimer>
    {
        [Observation]
        public void should_notify_the_timer_client()
        {
            client.was_told_to(c => c.notify());
        }

        ITimerFactory factory;
        ITimerClient client;
        Timer timer;

        protected override ITimer context()
        {
            factory = an<ITimerFactory>();
            client = an<ITimerClient>();
            timer = an<Timer>();

            factory.is_told_to(f => f.create_for(Arg<TimeSpan>.Is.Anything)).Return(timer);

            return new interval_timer(factory);
        }

        protected override void because()
        {
            sut.start_notifying(client, new TimeSpan(0, 10, 0));
            timer.Raise(t => t.Elapsed += null, null, null);
        }
    }

    [Concern(typeof (interval_timer))]
    public class when_stopping_notifications_for_an_existing_timer_client : old_context_specification<ITimer>
    {
        ITimerClient client;
        Timer timer;

        [Observation]
        public void should_stop_the_timer_that_was_started_for_the_client()
        {
            timer.was_told_to(t => t.Stop());
        }

        [Observation]
        public void should_dispose_the_timer_that_was_started_for_the_client()
        {
            timer.was_told_to(t => t.Dispose());
        }

        protected override ITimer context()
        {
            client = an<ITimerClient>();
            var factory = an<ITimerFactory>();
            timer = an<Timer>();

            factory
                .is_told_to(t => t.create_for(Arg<TimeSpan>.Is.Anything))
                .Return(timer);
            return new interval_timer(factory);
        }

        protected override void because()
        {
            sut.start_notifying(client, new TimeSpan(0, 0, 1));
            sut.stop_notifying(client);
        }
    }

    [Concern(typeof (interval_timer))]
    public class when_attempting_to_stop_notification_for_a_client_that_doesnt_have_a_timer_started_for_it :
        old_context_specification<ITimer>
    {
        [Observation]
        public void should_not_blow_up()
        {
        }

        ITimerClient client;

        protected override ITimer context()
        {
            client = an<ITimerClient>();
            return new interval_timer(null);
        }

        protected override void because()
        {
            sut.stop_notifying(client);
        }
    }
}