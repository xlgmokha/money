using System.Collections;
using MbUnit.Core.Framework;
using MbUnit.Core.Invokers;
using MoMoney.boot.container;

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
                new wire_up_the_container().run();
                return Invoker.Execute(o, args);
            }
            finally
            {
                new tear_down_the_container().run();
            }
        }
    }
}