using System;
using System.Collections.Generic;
using System.Linq;
using MoMoney.Utility.Core;

namespace MoMoney.Utility.Extensions
{
    public static class mapping_extensions
    {
        public static Output map_using<Input, Output>(this Input item, Converter<Input, Output> conversion)
        {
            return conversion(item);
        }

        public static IEnumerable<Output> map_all_using<Input, Output>(this IEnumerable<Input> items,
                                                                       Converter<Input, Output> mapper)
        {
            return null == items ? new List<Output>() : items.Select(x => mapper(x));
        }

        public static IEnumerable<Output> map_all_using<Input, Output>(this IEnumerable<Input> items,
                                                                       IMapper<Input, Output> mapper)
        {
            return null == items ? new List<Output>() : items.Select(x => mapper.map_from(x));
        }

        public static IMapper<Left, Right> then<Left, Middle, Right>(this IMapper<Left, Middle> left,
                                                                     IMapper<Middle, Right> right)
        {
            return new chained_mapper<Left, Middle, Right>(left, right);
        }
    }
}