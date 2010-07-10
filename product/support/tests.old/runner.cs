using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace tests
{
    public delegate void after_the_sut_has_been_created();

    public abstract class runner<SUT> : test
    {
        static IDictionary<Type, object> dependencies = new Dictionary<Type, object>();
        ConstructorInfo greediest_constructor;

        static protected SUT sut { get; private set; }

        public override void initialize()
        {
            auto_register_dependencies();

            context();
            sut = create_sut();
            after_create_sut();
            because();
        }

        protected virtual void after_create_sut()
        {
            GetType().run_stacked<after_the_sut_has_been_created>(this);
        }

        public virtual SUT create_sut()
        {
            return (SUT) greediest_constructor.Invoke(dependencies.Values.ToArray());
        }

        protected void it(string should, Action<SUT> test)
        {
            it(should, () =>
            {
                test(sut);
            });
        }

        static protected T dependency<T>() where T : class
        {
            if (dependencies.ContainsKey(typeof (T)))
            {
                return (T) dependencies[typeof (T)];
            }
            return mock_factory.create<T>();
        }

        void auto_register_dependencies()
        {
            dependencies.Clear();
            greediest_constructor = typeof (SUT).find_the_greediest_constructor();
            if (null == greediest_constructor) return;
            greediest_constructor.GetParameters().each(x => register_dependency(x.ParameterType));
        }

        void register_dependency(Type dependency)
        {
            if (dependency.IsValueType)
                dependencies[dependency] = Activator.CreateInstance(dependency);
            else
                dependencies[dependency] = mock_factory.create(dependency);
        }
    }
}