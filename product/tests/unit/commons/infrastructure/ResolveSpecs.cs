using System;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using gorilla.commons.utility;

namespace Gorilla.Commons.Infrastructure.Container
{
    [Concern(typeof (Resolve))]
    public abstract class behaves_like_a_inversion_of_control_container : concerns
    {
    }

    [Concern(typeof(Resolve))]
    public class when_resolving_a_dependency_using_the_container : behaves_like_a_inversion_of_control_container
    {
        context c = () =>
                        {
                            registry = an<DependencyRegistry>();
                            presenter = an<Command>();
                            registry.is_told_to(x => x.get_a<Command>()).it_will_return(presenter);
                            Resolve.initialize_with(registry);
                        };

        because b = () => { result = Resolve.the<Command>(); };

        it should_leverage_the_underlying_container_it_was_initialized_with =
            () => registry.was_told_to(x => x.get_a<Command>());

        it should_return_the_resolved_dependency = () => result.should_be_equal_to(presenter);

        after_each_observation a = () => Resolve.initialize_with(null);

        static DependencyRegistry registry;
        static Command result;
        static Command presenter;
    }

    [Concern(typeof(Resolve))]
    public class when_resolving_a_dependency_that_is_not_registered_ : behaves_like_a_inversion_of_control_container
    {
        context c = () =>
                        {
                            registry = an<DependencyRegistry>();
                            registry.is_told_to(x => x.get_a<Command>()).it_will_throw(new Exception());
                            Resolve.initialize_with(registry);
                        };

        because b = () => { the_call = call.to(() => Resolve.the<Command>()); };

        after_each_observation a = () => Resolve.initialize_with(null);

        it should_throw_a_dependency_resolution_exception =
            () => the_call.should_have_thrown<DependencyResolutionException<Command>>();

        static DependencyRegistry registry;
        static Action the_call;
    }
}