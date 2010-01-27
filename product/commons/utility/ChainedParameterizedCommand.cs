namespace gorilla.commons.utility
{
    public class ChainedParameterizedCommand<T> : ParameterizedCommand<T>
    {
        ParameterizedCommand<T> left;
        ParameterizedCommand<T> right;

        public ChainedParameterizedCommand(ParameterizedCommand<T> left, ParameterizedCommand<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public void run(T item)
        {
            left.run(item);
            right.run(item);
        }
    }
}