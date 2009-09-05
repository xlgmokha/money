using System;
using System.Linq.Expressions;

namespace MoMoney.boot.container.registration.mapping
{
    public class MappingStepFactory : IMappingStepFactory
    {
        private readonly ITargetActionFactory target_action_factory;

        public MappingStepFactory() : this(new TargetActionFactory())
        {
        }

        public MappingStepFactory(ITargetActionFactory target_action_factory)
        {
            this.target_action_factory = target_action_factory;
        }

        public IMappingStep<Source, Destination> create_mapping_step_for<Source, Destination, PropertyType>(
            Expression<Func<Source, PropertyType>> source_expression,
            Expression<Func<Destination, PropertyType>> destination_expression)
        {
            var source_evaluator = new ExpressionSourceEvaluator<Source, PropertyType>(source_expression);

            var target_action = target_action_factory.create_action_target_from(destination_expression);

            return new MappingStep<Source, Destination, PropertyType>(source_evaluator, target_action);
        }
    }
}