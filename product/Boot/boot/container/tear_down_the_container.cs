using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.boot.container
{
    class tear_down_the_container : ICommand
    {
        public void run()
        {
            Resolve.initialize_with(null);
        }
    }
}