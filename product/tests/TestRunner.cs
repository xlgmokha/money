using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace tests
{
    static class TestRunner
    {
        static public void run_stacked<Delegate>(this Type target, object instance)
        {
            var stack = new Stack<Type>();
            target.class_hierarchy(x => stack.Push(x));
            stack.each(x => x.run_single<Delegate>(instance));
        }

        static public void run_single<Delegate>(this IReflect target, object instance)
        {
            var fields = target.collect_fields_of_type<Delegate>();
            if (fields.Count() > 0)
            {
                fields
                    .First()
                    .GetValue(instance)
                    .downcast_to<System.Delegate>()
                    .DynamicInvoke();
            }
        }

        static public void run_all<Delegate>(this IReflect target, object target_instance)
        {
            target
                .collect_fields_of_type<Delegate>()
                .each(x =>
                {
                    try
                    {
                        Console.Out.Write("{0}", x);
                        x.invoke_delegate_on(target_instance);
                        Console.Out.WriteLine(" :PASSED");
                    }
                    catch (Exception e)
                    {
                        throw e.InnerException;
                    }
                });
        }

        static public void run(this KeyValuePair<string, it> specification)
        {
            try
            {
                Console.Out.Write("it {0}", specification.Key);
                specification.Value();
                Console.Out.WriteLine(" :PASSED");
            }
            catch
            {
                Console.Out.WriteLine(" :FAILED");
                throw;
            }
        }
    }
}