using System.Collections.Generic;
using MoMoney.Infrastructure.proxies.Interceptors;

namespace MoMoney.Infrastructure.proxies
{
    public interface IInterceptorConstraint<TypeToPutConstraintOn> : IConstraintSelector<TypeToPutConstraintOn>
    {
        IEnumerable<string> methods_to_intercept();
    }

    public class InterceptorConstraint<TypeToPutConstraintOn> : IInterceptorConstraint<TypeToPutConstraintOn>
    {
        private readonly IMethodCallTracker<TypeToPutConstraintOn> call_tracker;

        public InterceptorConstraint(IMethodCallTracker<TypeToPutConstraintOn> call_tracker)
        {
            this.call_tracker = call_tracker;
        }

        public TypeToPutConstraintOn InterceptOn
        {
            get { return call_tracker.target; }
        }

        public IEnumerable<string> methods_to_intercept()
        {
            return call_tracker.methods_to_intercept();
        }
    }
}