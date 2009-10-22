using Castle.Core.Interceptor;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using gorilla.commons.utility;

namespace MoMoney.boot.container.registration.proxy_configuration
{
    public class InterceptingFilterFactorySpecs
    {
        public class when_creating_an_intercepting_filter :
            concerns_for<IInterceptingFilterFactory, InterceptingFilterFactory>
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