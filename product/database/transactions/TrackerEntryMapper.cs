using Gorilla.Commons.Infrastructure.Cloning;
using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public interface ITrackerEntryMapper<T> : Mapper<T, ITrackerEntry<T>> {}

    public class TrackerEntryMapper<T> : ITrackerEntryMapper<T>
    {
        readonly IPrototype prototype;

        public TrackerEntryMapper(IPrototype prototype)
        {
            this.prototype = prototype;
        }

        public ITrackerEntry<T> map_from(T item)
        {
            return new TrackerEntry<T>(create_prototype(item), item);
        }

        T create_prototype(T item)
        {
            return prototype.clone(item);
        }
    }
}