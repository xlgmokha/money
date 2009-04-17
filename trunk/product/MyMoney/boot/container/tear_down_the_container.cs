using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.Container;

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