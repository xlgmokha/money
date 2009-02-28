using System.Reflection;

namespace MyMoney.Infrastructure.transactions
{
    public interface IUnitOfWorkRegistration<T>
    {
        T current { get; }
        bool contains_changes();
    }

    public class UnitOfWorkRegistration<T> : IUnitOfWorkRegistration<T>
    {
        readonly T original;

        public UnitOfWorkRegistration(T original, T current)
        {
            this.original = original;
            this.current = current;
        }

        public T current { get; set; }

        public bool contains_changes()
        {
            var type = original.GetType();
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                var original_value = field.GetValue(original);
                var current_value = field.GetValue(current);
                if (original_value == null && current_value != null)
                {
                    return true;
                }
                if (original_value != null && !original_value.Equals(current_value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}