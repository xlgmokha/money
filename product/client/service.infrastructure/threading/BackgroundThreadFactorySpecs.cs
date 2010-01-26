using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Testing;
using gorilla.commons.Utility;

namespace momoney.service.infrastructure.threading
{
    [Concern(typeof (BackgroundThreadFactory))]
    public abstract class behaves_like_a_background_thread_factory : concerns_for<IBackgroundThreadFactory, BackgroundThreadFactory>
    {
        context c = () =>
        {
            registry = the_dependency<DependencyRegistry>();
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