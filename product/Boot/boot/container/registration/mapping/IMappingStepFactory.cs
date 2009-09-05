using System;
using System.Linq.Expressions;

namespace MoMoney.boot.container.registration.mapping
{
    public interface IMappingStepFactory
    {
        IMappingStep<Source, Destination> create_mapping_step_for<Source, Destination, PropertyType>(
            Expression<Func<Source, PropertyType>> source_expression,
            Expression<Func<Destination, PropertyType>> destination_expression);
    }
}