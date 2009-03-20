using MoMoney.Infrastructure.Container;
using MoMoney.Utility.Core;

namespace MoMoney.boot.container
{
    internal class tear_down_the_container : ICommand
    {
        public void run()
        {
            resolve.initialize_with(null);
        }
    }
}