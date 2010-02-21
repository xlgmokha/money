using System;

namespace presentation.windows.queries
{
    public interface QueryBuilder
    {
        void build<Query>(Action<Query> action) where Query : class;
    }
}