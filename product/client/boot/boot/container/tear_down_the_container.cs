using Gorilla.Commons.Infrastructure.Container;
using gorilla.commons.utility;

namespace MoMoney.boot.container
{
    class tear_down_the_container : Command
    {
        public void run()
        {
            Resolve.initialize_with(null);
        }
    }
}