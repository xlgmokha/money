using System.Collections;
using MbUnit.Core.Framework;
using MbUnit.Core.Invokers;
using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.windows.ui;

namespace MoMoney.Testing.MetaData
{
    public class run_in_real_container : DecoratorPatternAttribute
    {
        public override IRunInvoker GetInvoker(IRunInvoker wrapper)
        {
            return new run_in_real_container_interceptor(wrapper);
        }
    }

    public class run_in_real_container_interceptor : DecoratorRunInvoker
    {
        public run_in_real_container_interceptor(IRunInvoker wrapper) : base(wrapper)
        {
        }

        public override object Execute(object o, IList args)
        {
            try
            {
                //resolve.initialize_with(new WindsorDependencyRegistry());
                get_the.registry(null);
                return Invoker.Execute(o, args);
            }
            finally
            {
                resolve.initialize_with(null);
            }
        }
    }
}