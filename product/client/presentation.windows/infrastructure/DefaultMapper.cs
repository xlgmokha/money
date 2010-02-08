using gorilla.commons.utility;

namespace presentation.windows.infrastructure
{
    public class DefaultMapper : Mapper
    {
        public Output map_from<Input, Output>(Input item)
        {
            return AutoMapper.Mapper.Map<Input, Output>(item);
        }
    }
}