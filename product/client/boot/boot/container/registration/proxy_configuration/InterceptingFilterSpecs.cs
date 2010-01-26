using Castle.Core.Interceptor;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using gorilla.commons.utility;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    public class InterceptingFilterSpecs
    {
        public class when_intercepting_a_call : concerns_for<IInterceptor, InterceptingFilter>
        {
            context c = () =>
            {
                condition = the_dependency<Specification<IInvocation>>();
            };

            static protected Specification<IInvocation> condition;
        }

        public class when_a_condition_is_not_met : when_intercepting_a_call
        {
            context c = () =>
            {
                invocation = an<IInvocation>();
                when_the(condition).is_told_to(x => x.is_satisfied_by(invocation)).it_will_return(false);
            };

            because b = () => sut.Intercept(invocation);

            it should_not_forward_the_call_to_the_target = () => invocation.was_not_told_to(x => x.Proceed());

            static IInvocation invocation;
        }

        public class when_a_condition_is_met : when_intercepting_a_call
        {
            context c = () =>
            {
                invocation = an<IInvocation>();
                when_the(condition).is_told_to(x => x.is_satisfied_by(invocation)).it_will_return(true);
            };

            because b = () => sut.Intercept(invocation);

            it should_forward_the_call_to_the_target = () => invocation.was_told_to(x => x.Proceed());

            static IInvocation invocation;
        }
    }
}