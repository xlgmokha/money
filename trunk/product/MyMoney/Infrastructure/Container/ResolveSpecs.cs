using System;
using developwithpassion.bdd.contexts;
using MoMoney.Presentation.Core;
using MoMoney.Testing;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Infrastructure.Container
{
    [Concern(typeof (resolve))]
    public abstract class behaves_like_a_inversion_of_control_container : concerns
    {
    }

    public class when_resolving_a_dependency_using_the_container : behaves_like_a_inversion_of_control_container
    {
        context c = () =>
                        {
                            registry = an<IDependencyRegistry>();
                            presenter = an<IPresenter>();
                            registry.is_told_to(x => x.get_a<IPresenter>()).it_will_return(presenter);
                            resolve.initialize_with(registry);
                        };

        because b = () => { result = resolve.dependency_for<IPresenter>(); };

        it should_leverage_the_underlying_container_it_was_initialized_with =
            () => registry.was_told_to(x => x.get_a<IPresenter>());

        it should_return_the_resolved_dependency = () => result.should_be_equal_to(presenter);

        after_each_observation a = () => resolve.initialize_with(null);

        static IDependencyRegistry registry;
        static IPresenter result;
        static IPresenter presenter;
    }

    public class when_resolving_a_dependency_that_is_not_registered_ : behaves_like_a_inversion_of_control_container
    {
        context c = () =>
                        {
                            registry = an<IDependencyRegistry>();
                            registry.is_told_to(x => x.get_a<IPresenter>()).it_will_throw(new Exception());
                            resolve.initialize_with(registry);
                        };

        because b = () => { the_call = call.to(() => resolve.dependency_for<IPresenter>()); };

        after_each_observation a = () => resolve.initialize_with(null);

        it should_throw_a_dependency_resolution_exception =
            () => the_call.should_have_thrown<dependency_resolution_exception<IPresenter>>();

        static IDependencyRegistry registry;
        static Action the_call;
    }
}