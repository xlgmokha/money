using gorilla.commons.infrastructure.thirdparty.Castle.DynamicProxy;

namespace tests.unit.commons.infrastructure.thirdparty.castle
{
    [Concern(typeof (CastleDynamicInterceptorConstraintFactory))]
    public abstract class behaves_like_constraint_factory : runner<CastleDynamicInterceptorConstraintFactory>
    {
        context c = () =>
        {
            method_call_tracker_factory = dependency<MethodCallTrackerFactory>();
        };

        static protected MethodCallTrackerFactory method_call_tracker_factory;
    }

    [Concern(typeof (CastleDynamicInterceptorConstraintFactory))]
    public class when_creating_a_constraint_for_a_type_to_intercept_on : behaves_like_constraint_factory
    {
        static InterceptorConstraint<string> result;

        it should_create_a_method_call_tracker_for_the_type_to_place_a_constraint_on =
            () => method_call_tracker_factory.was_told_to(f => f.create_for<string>());

        it should_return_an_instance_of_an_interceptor_constraint =
            () => result.should_be_an_instance_of<CastleDynamicInterceptorConstraint<string>>();

        because b = () =>
        {
            result = sut.CreateFor<string>();
        };
    }
}