using Castle.Core.Interceptor;
using gorilla.commons.utility;
using gorilla.commons.Utility;
using momoney.service.infrastructure.threading;

namespace tests.unit.client.service.infrastructure.threading
{
    [Concern(typeof (RunOnBackgroundThreadInterceptor<>))]
    public abstract class behaves_like_background_thread_interceptor : runner<RunOnBackgroundThreadInterceptor<DisposableCommand>>
    {
        context c = () =>
        {
            thread_factory = dependency<IBackgroundThreadFactory>();
        };

        static protected IBackgroundThreadFactory thread_factory;
    }

    [Concern(typeof (RunOnBackgroundThreadInterceptor<>))]
    public class when_intercepting_a_call_to_a_method_that_takes_a_long_time_to_complete :
        behaves_like_background_thread_interceptor
    {
        context c = () =>
        {
            invocation = an<IInvocation>();
            background_thread = an<IBackgroundThread>();
            thread_factory
                .is_told_to(f => f.create_for<DisposableCommand>())
                .it_will_return(background_thread);
        };

        because b = () => sut.Intercept(invocation);

        it should_display_a_progress_bar_on_a_background_thread =
            () => thread_factory.was_told_to(f => f.create_for<DisposableCommand>());

        it should_proceed_with_the_orginal_invocation_on_the_actual_object =
            () => invocation.was_told_to(i => i.Proceed());

        it should_hide_the_progress_bar_when_the_invocation_is_completed =
            () => background_thread.was_told_to(b => b.Dispose());

        static IInvocation invocation;
        static IBackgroundThread background_thread;
    }
}