using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Infrastructure.proxies.Interceptors;
using MoMoney.Utility.Extensions;

namespace MoMoney.Infrastructure.proxies
{
    public interface IInterceptorConstraint<TypeToPutConstraintOn> : IConstraintSelector<TypeToPutConstraintOn>
    {
        IEnumerable<string> methods_to_intercept();
    }

    public class InterceptorConstraint<TypeToPutConstraintOn> : IInterceptorConstraint<TypeToPutConstraintOn>
    {
        readonly IMethodCallTracker<TypeToPutConstraintOn> call_tracker;

        public InterceptorConstraint(IMethodCallTracker<TypeToPutConstraintOn> call_tracker)
        {
            this.call_tracker = call_tracker;
        }

        public TypeToPutConstraintOn InterceptOn
        {
            get { return call_tracker.target; }
        }

        public void InterceptAll()
        {
            var methods = typeof (TypeToPutConstraintOn).GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (var method in methods)
            {
                if (method.ContainsGenericParameters)
                {
                    method
                        .MakeGenericMethod(typeof(Component))
                        .Invoke(InterceptOn, get_stub_parameters_for(method).ToArray());
                }
                else
                {
                    method.Invoke(InterceptOn, get_stub_parameters_for(method).ToArray());
                }
            }
        }

        IEnumerable<object> get_stub_parameters_for(MethodInfo method)
        {
            foreach (var parameter in method.GetParameters())
            {
                this.log().debug("method: {0}, param: {1}", method, parameter);
                yield return parameter.ParameterType.default_value();
            }
        }

        public IEnumerable<string> methods_to_intercept()
        {
            return call_tracker.methods_to_intercept();
        }
    }
}