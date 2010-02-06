namespace gorilla.commons.utility
{
    public class ChainedCommand<T> : ArgCommand<T>
    {
        ArgCommand<T> left;
        ArgCommand<T> right;

        public ChainedCommand(ArgCommand<T> left, ArgCommand<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public void run_against(T item)
        {
            left.run_against(item);
            right.run_against(item);
        }
    }
}