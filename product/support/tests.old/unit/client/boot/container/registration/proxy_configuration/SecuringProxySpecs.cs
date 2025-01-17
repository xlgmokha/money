using System.Security.Principal;
using System.Threading;
using Castle.Core.Interceptor;
using gorilla.commons.utility;
using MoMoney.boot.container.registration.proxy_configuration;

namespace tests.unit.client.boot.container.registration.proxy_configuration
{
    public class SecuringProxySpecs {}

    public class when_attempting_to_perform_an_action_that_requires_authentication :
        tests_for<SecuringProxy>
    {
        context c = () =>
        {
            filter = dependency<Specification<IPrincipal>>();
        };

        static protected Specification<IPrincipal> filter;
    }

    public class when_logged_in_as_a_user_that_belongs_to_the_proper_role :
        when_attempting_to_perform_an_action_that_requires_authentication
    {
        context c = () =>
        {
            invocation = an<IInvocation>();
            filter
                .is_told_to(x => x.is_satisfied_by(Thread.CurrentPrincipal))
                .it_will_return(true);
        };

        because b = () => sut.Intercept(invocation);

        it should_proceed_with_request = () => invocation.was_told_to(x => x.Proceed());

        static IInvocation invocation;
    }

    public class when_not_logged_in_as_a_user_that_belongs_to_the_proper_role :
        when_attempting_to_perform_an_action_that_requires_authentication
    {
        context c = () =>
        {
            invocation = an<IInvocation>();
            filter
                .is_told_to(x => x.is_satisfied_by(Thread.CurrentPrincipal))
                .it_will_return(false);
        };

        because b = () => sut.Intercept(invocation);

        it should_not_proceed_with_request = () => invocation.was_not_told_to(x => x.Proceed());

        static IInvocation invocation;
    }
}