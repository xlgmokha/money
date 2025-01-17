using Castle.Core.Interceptor;
using gorilla.commons.utility;
using MoMoney.boot.container.registration.proxy_configuration;

namespace tests.unit.client.boot.container.registration.proxy_configuration
{
    public class InterceptingFilterFactorySpecs
    {
        [Concern(typeof (InterceptingFilterFactory))]
        public class when_creating_an_intercepting_filter : runner<InterceptingFilterFactory>
        {
            context c = () =>
            {
                condition = an<Specification<IInvocation>>();
            };

            because b = () =>
            {
                result = sut.create_for(condition);
            };

            it should_return_a_filter = () =>
            {
                result.should_not_be_null();
                result.should_be_an_instance_of<InterceptingFilter>();
            };

            static Specification<IInvocation> condition;
            static IInterceptor result;
        }
    }
}