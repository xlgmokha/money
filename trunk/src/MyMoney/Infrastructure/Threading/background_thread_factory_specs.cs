using jpboodhoo.bdd.contexts;
using MyMoney.Infrastructure.Container;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Utility.Core;
using assertion_extensions=MyMoney.Testing.spechelpers.core.assertion_extensions;
using mocking_extensions=MyMoney.Testing.spechelpers.core.mocking_extensions;

namespace MyMoney.Infrastructure.Threading
{
    [Concern(typeof (background_thread_factory))]
    public abstract class behaves_like_a_background_thread_factory : concerns_for<IBackgroundThreadFactory, background_thread_factory>
    {
        public override IBackgroundThreadFactory create_sut()
        {
            return new background_thread_factory(registry);
        }

        context c = () => { registry = the_dependency<IDependencyRegistry>(); };

        protected static IDependencyRegistry registry;
    }

    public class when_creating_a_background_thread : behaves_like_a_background_thread_factory
    {
        it should_return_an_instance_of_a_background_thread = () => assertion_extensions.should_not_be_null(result);

        it should_lookup_an_instance_of_the_command_to_execute =
            () => mocking_extensions.was_told_to(registry, r => r.find_an_implementation_of<IDisposableCommand>());

        because b = () => { result = sut.create_for<IDisposableCommand>(); };

        static IBackgroundThread result;
    }
}