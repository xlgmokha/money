using System;
using MoMoney.Domain.Core;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Container.Windsor.configuration
{
    public class IsAnEntity : ISpecification<Type>
    {
        public bool is_satisfied_by(Type item)
        {
            return typeof (IEntity).IsAssignableFrom(item);
        }
    }
}