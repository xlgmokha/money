using System;
using System.Linq.Expressions;

namespace MoMoney.boot.container.registration.mapping
{
    public class TargetActionFactory : ITargetActionFactory
    {
        readonly IPropertyResolver property_resolver;

        public TargetActionFactory(IPropertyResolver property_resolver)
        {
            this.property_resolver = property_resolver;
        }

        public TargetActionFactory() : this(new PropertyResolver())
        {
        }

        public ITargetAction<Target, ValueType> create_action_target_from<Target, ValueType>(
            Expression<Func<Target, ValueType>> target_expression)
        {
            var property = property_resolver.resolve_using(target_expression);
            if (property.CanWrite)
                return new DelegateTargetAction<Target, ValueType>((x, y) => property.SetValue(x, y, new object[0]));

            throw new ImmutablePropertyException(typeof (Target), property);
        }
    }
}