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
                        x.invoke_delegate_on(target_instance);
                        Console.Out.WriteLine("  {0}", x);
                    }
                    catch (Exception e)
                    {
                        Console.Out.WriteLine(":FAILED {0}", x);
                        throw e.InnerException;
                    }
                });
        }

        static public void run(this KeyValuePair<string, it> specification)
        {
            try
            {
                specification.Value();
                Console.Out.WriteLine("  it {0}", specification.Key);
            }
            catch
            {
                Console.Out.WriteLine(":FAILED it {0}", specification.Key);
                throw;
            }
        }
    }
}