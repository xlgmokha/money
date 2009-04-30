using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.boot.container.registration.mapping
{
    public class Map<Input, Output> : IMap<Input, Output>
    {
        private IMapInitializationStep<Output> map_initialization_step;
        private readonly IList<IMappingStep<Input, Output>> mapping_steps;
        private readonly IMappingStepFactory mapping_step_factory;

        public Map() : this(new MappingStepFactory())
        {
        }

        public Map(IMappingStepFactory mapping_step_factory)
            : this(
                new MissingInitializationStep<Output>(), new List<IMappingStep<Input, Output>>(), mapping_step_factory)
        {
        }

        public Map(IMapInitializationStep<Output> map_initialization_step,
                   IList<IMappingStep<Input, Output>> mapping_steps, IMappingStepFactory mapping_step_factory)
        {
            this.map_initialization_step = map_initialization_step;
            this.mapping_steps = mapping_steps;
            this.mapping_step_factory = mapping_step_factory;
        }

        public void add(IMappingStep<Input, Output> step)
        {
            mapping_steps.Add(step);
        }

        public IMap<Input, Output> map<PropertyType>(Expression<Func<Input, PropertyType>> from,
                                                     Expression<Func<Output, PropertyType>> to)
        {
            add(mapping_step_factory.create_mapping_step_for(from, to));
            return this;
        }

        public IMap<Input, Output> initialize_mapping_using(Func<Output> initializer_expression)
        {
            map_initialization_step = new FuncInitializationStep<Output>(initializer_expression);
            return this;
        }

        public Output map_from(Input input)
        {
            var output = map_initialization_step.initialize();
            mapping_steps.each(x => x.map(input, output));
            return output;
        }
    }
}