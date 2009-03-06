namespace MoMoney.Utility.Core
{
    internal class chained_command : ICommand
    {
        private readonly ICommand left;
        private readonly ICommand right;

        public chained_command(ICommand left, ICommand right)
        {
            this.left = left;
            this.right = right;
        }

        public void run()
        {
            left.run();
            right.run();
        }
    }
}