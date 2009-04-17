using System;

namespace MoMoney.Utility.Core
{
    public class Map<Input, Output> : IMapper<Input, Output>
    {
        private readonly Converter<Input, Output> converter;

        public Map(Converter<Input, Output> converter)
        {
            this.converter = converter;
        }

        public Output map_from(Input item)
        {
            return converter(item);
        }
    }
}