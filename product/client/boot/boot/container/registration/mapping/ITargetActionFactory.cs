using System;
using System.Linq.Expressions;

namespace MoMoney.boot.container.registration.mapping
{
    public interface ITargetActionFactory
    {
        ITargetAction<Target, ValueType> create_action_target_from<Target, ValueType>(
            Expression<Func<Target, ValueType>> target_expression);
    }
}