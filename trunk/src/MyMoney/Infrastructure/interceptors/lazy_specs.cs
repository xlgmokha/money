using jpboodhoo.bdd.contexts;
using MyMoney.Infrastructure.Container;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using mocking_extensions=MyMoney.Testing.spechelpers.core.mocking_extensions;

namespace MyMoney.Infrastructure.interceptors
{
    [Concern(typeof (lazy))]
    public abstract class behaves_like_a_lazy_loaded_object : concerns_for
    {
        context c = () =>
                        {
                            test_container = dependency<IDependencyRegistry>();
                            resolve.initialize_with(test_container);
                        };

        after_each_observation a = () => resolve.initialize_with(null);

        protected static IDependencyRegistry test_container;
    }

    public class when_calling_a_method_with_no_arguments_on_a_lazy_loaded_proxy : behaves_like_a_lazy_loaded_object
    {
        it should_forward_the_original_call_to_the_target = () => mocking_extensions.was_told_to(target, t => t.OneMethod());

        context c = () =>
                        {
                            target = an<ITargetObject>();
                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(test_container, t => t.find_an_implementation_of<ITargetObject>()), target).Repeat.Once();
                        };

        because b = () =>
                        {
                            var result = lazy.Load<ITargetObject>();
                            result.OneMethod();
                        };

        static ITargetObject target;
    }

    public class when_calling_a_method_that_returns_an_argument_on_a_lazy_loaded_proxy :
        behaves_like_a_lazy_loaded_object
    {
        it should_return_the_value_from_the_actual_target = () => result.should_be_equal_to(10);

        context c = () =>
                        {
                            var target = an<ITargetObject>();

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(target, x => x.FirstValueReturningMethod()), 10);
                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(test_container, t => t.find_an_implementation_of<ITargetObject>()), target)
                                .Repeat.Once();
                        };

        because b = () =>
                        {
                            var proxy = lazy.Load<ITargetObject>();
                            result = proxy.FirstValueReturningMethod();
                        };

        static int result;
    }

    public class when_calling_different_methods_on_an_proxied_object : behaves_like_a_lazy_loaded_object
    {
        it should_only_load_the_object_once =
            () => mocking_extensions.was_told_to(test_container, x => x.find_an_implementation_of<ITargetObject>()).only_once();

        context c = () =>
                        {
                            var target = an<ITargetObject>();
                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(test_container, t => t.find_an_implementation_of<ITargetObject>()), target).Repeat.Once();
                        };

        because b = () =>
                        {
                            var proxy = lazy.Load<ITargetObject>();
                            proxy.SecondMethod();
                            proxy.FirstValueReturningMethod();
                        };
    }

    public class when_calling_a_method_that_takes_in_a_single_input_parameter_on_a_proxied_object :
        behaves_like_a_lazy_loaded_object
    {
        it should_forward_the_call_to_the_original_target =
            () => mocking_extensions.was_told_to(target, x => x.ValueReturningMethodWithAnArgument(88));

        it should_return_the_correct_result = () => result.should_be_equal_to(99);

        context c = () =>
                        {
                            target = an<ITargetObject>();

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(target, x => x.ValueReturningMethodWithAnArgument(88)), 99);
                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(test_container, t => t.find_an_implementation_of<ITargetObject>()), target).Repeat.Once();
                        };

        because b = () =>
                        {
                            var proxy = lazy.Load<ITargetObject>();
                            result = proxy.ValueReturningMethodWithAnArgument(88);
                        };

        static ITargetObject target;
        static int result;
    }

    public class when_accessing_the_value_of_a_property_on_a_proxied_object : behaves_like_a_lazy_loaded_object
    {
        it should_return_the_correct_value = () => result.should_be_equal_to("mo");

        context c = () =>
                        {
                            var target = an<ITargetObject>();

                            target.GetterAndSetterProperty = "mo";
                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(test_container, t => t.find_an_implementation_of<ITargetObject>()), target).Repeat.Once();
                        };

        because b = () =>
                        {
                            var proxy = lazy.Load<ITargetObject>();
                            result = proxy.GetterAndSetterProperty;
                        };

        static string result;
    }

    public class when_setting_the_value_of_a_property_on_a_proxied_object : behaves_like_a_lazy_loaded_object
    {
        it should_set_the_value_on_the_original_target =
            () => mocking_extensions.was_told_to(target, x => x.GetterAndSetterProperty = "khan");

        context c = () =>
                        {
                            target = dependency<ITargetObject>();

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(test_container, t => t.find_an_implementation_of<ITargetObject>()), target)
                                .Repeat.Once();
                        };

        because b = () =>
                        {
                            var proxy = lazy.Load<ITargetObject>();
                            proxy.GetterAndSetterProperty = "khan";
                        };

        static ITargetObject target;
    }

    public class when_calling_a_generic_method_on_a_proxied_object : behaves_like_a_lazy_loaded_object
    {
        it should_forward_the_call_to_the_target =
            () => mocking_extensions.was_told_to(target, x => x.ValueReturningMethodWithAnArgument("blah"));

        it should_return_the_correct_result = () => result.should_be_equal_to("hooray");

        context c = () =>
                        {
                            target = an<IGenericInterface<string>>();

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(target, x => x.ValueReturningMethodWithAnArgument("blah")), "hooray");
                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(test_container, t => t.find_an_implementation_of<IGenericInterface<string>>()), target).Repeat.Once();
                        };

        because b = () =>
                        {
                            var proxy = lazy.Load<IGenericInterface<string>>();
                            result = proxy.ValueReturningMethodWithAnArgument("blah");
                        };

        static IGenericInterface<string> target;
        static string result;
    }

    public interface IGenericInterface<T>
    {
        T GetterAndSetterProperty { get; set; }
        void OneMethod();
        void SecondMethod();
        T FirstValueReturningMethod();
        T ValueReturningMethodWithAnArgument(T item);
    }

    public interface ITargetObject
    {
        string GetterAndSetterProperty { get; set; }
        void OneMethod();
        void SecondMethod();
        int FirstValueReturningMethod();
        int ValueReturningMethodWithAnArgument(int number);
    }
}