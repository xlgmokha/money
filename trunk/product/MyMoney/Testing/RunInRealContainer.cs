using System.Collections;
using MbUnit.Core.Framework;
using MbUnit.Core.Invokers;
using MoMoney.boot.container;

namespace MoMoney.Testing.MetaData
{
    public class RunInRealContainer : DecoratorPatternAttribute
    {
        public override IRunInvoker GetInvoker(IRunInvoker wrapper)
        {
            return new RunInRealContainerInterceptor(wrapper);
        }
    }

    public class RunInRealContainerInterceptor : DecoratorRunInvoker
    {
        public RunInRealContainerInterceptor(IRunInvoker wrapper) : base(wrapper)
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