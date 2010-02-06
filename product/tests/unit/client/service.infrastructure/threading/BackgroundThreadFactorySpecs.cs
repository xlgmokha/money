using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.Utility;
using momoney.service.infrastructure.threading;

namespace tests.unit.client.service.infrastructure.threading
{
    [Concern(typeof (BackgroundThreadFactory))]
    public abstract class behaves_like_a_background_thread_factory : runner<BackgroundThreadFactory>
    {
        context c = () =>
        {
            registry = dependency<DependencyRegistry>();
        };

        static protected DependencyRegistry registry;
    }

    [Concern(typeof (BackgroundThreadFactory))]
    public class when_creating_a_background_thread : behaves_like_a_background_thread_factory
    {
        it should_return_an_instance_of_a_background_thread = () => result.should_not_be_null();

        it should_lookup_an_instance_of_the_command_to_execute =
            () => registry.was_told_to(r => r.get_a<DisposableCommand>());

        because b = () =>
        {
            result = sut.create_for<DisposableCommand>();
        };

        static IBackgroundThread result;
    }
}