using System;
using System.Data;
using Castle.Core.Interceptor;
using jpboodhoo.bdd;
using jpboodhoo.bdd.contexts;
using jpboodhoo.bdd.mbunit;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;

namespace MoMoney.Infrastructure.proxies
{
    [Concern(typeof(ProxyFactory))]
    public abstract class behaves_like_proxy_factory : concerns_for<IProxyFactory, ProxyFactory>
    {
        public override IProxyFactory create_sut()
        {
            return new ProxyFactory();
        }
    }

    public class when_creating_a_proxy_with_a_target : behaves_like_proxy_factory
    {
        it should_forward_all_calls_to_the_target = () => target.was_told_to(x => x.Open());

        it should_return_a_proxy_to_the_target = () =>
                                                     {
                                                         result.should_not_be_null();
                                                         result.GetType().should_not_be_equal_to(target.GetType());
                                                     };

        it should_allow_the_interceptors_to_intercept_all_calls =
            () => interceptor.recieved_call.should_be_true();

        context c = () => { target = the_dependency<IDbConnection>(); };

        because b = () =>
                        {
                            interceptor = new TestInterceptor();
                            result = sut.create_proxy_for(() => target, interceptor);
                            result.Open();
                        };

        static IDbConnection target;
        static IDbConnection result;
        static TestInterceptor interceptor;
    }

    public class when_creating_a_proxy_of_a_target_but_a_call_has_not_been_made_to_the_proxy_yet :
        behaves_like_proxy_factory
    {
        it should_not_create_an_instance_of_the_target = () => TestClass.was_created.should_be_false();

        context c = TestClass.reset;

        because b = () => { result = sut.create_proxy_for<IDisposable>(() => new TestClass()); };

        after_each_observation ae = TestClass.reset;

        static IDisposable result;
    }

    public class when_creating_a_proxy_of_a_component_that_does_not_implement_an_interface : behaves_like_proxy_factory
    {
        it should_return_a_proxy = () => result.should_not_be_null();

        because b = () => { result = sut.create_proxy_for(() => new ClassWithNoInterface()); };

        after_each_observation ae = TestClass.reset;

        static ClassWithNoInterface result;
    }

    public class ClassWithNoInterface
    {
    }

    public class TestClass : IDisposable
    {
        public static bool was_created;

        public TestClass()
        {
            was_created = true;
        }

        public static void reset()
        {
            was_created = false;
        }

        public void Dispose()
        {
        }
    }


    public class TestInterceptor : IInterceptor
    {
        public bool recieved_call { get; set; }

        public void Intercept(IInvocation invocation)
        {
            recieved_call = true;
            invocation.Proceed();
        }
    }
}