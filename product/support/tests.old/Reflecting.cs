using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace tests
{
    static class Reflecting
    {
        static public void class_hierarchy(this Type target, Action<Type> action)
        {
            action(target);
            var base_class = target.BaseType;
            if (null != base_class) base_class.class_hierarchy(action);
        }

        static public IEnumerable<FieldInfo> collect_fields_of_type<T>(this IReflect target)
        {
            return target
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.FieldType.Equals(typeof (T)));
        }

        static public void invoke_delegate_on(this FieldInfo field, object target)
        {
            field.GetValue(target).downcast_to<Delegate>().DynamicInvoke();
        }

        static public ConstructorInfo find_the_greediest_constructor(this Type type)
        {
            var all = type.GetConstructors();
            ConstructorInfo greediest = null;
            foreach (var constructor in all)
            {
                if (null == greediest)
                {
                    greediest = constructor;
                    continue;
                }
                if (constructor.GetParameters().Length > greediest.GetParameters().Length)
                {
                    greediest = constructor;
                }
            }
            return greediest;
        }
    }
}