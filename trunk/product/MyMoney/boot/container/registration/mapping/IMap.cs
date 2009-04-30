using System;
using System.Linq.Expressions;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.boot.container.registration.mapping
{
    public interface IMap<Input, Output> : IMapper<Input, Output>
    {
        void add(IMappingStep<Input, Output> step);

        IMap<Input, Output> map<PropertyType>(Expression<Func<Input, PropertyType>> from,
                                              Expression<Func<Output, PropertyType>> to);

        IMap<Input, Output> initialize_mapping_using(Func<Output> initializer_expression);
    }
}