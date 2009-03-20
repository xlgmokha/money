using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.windows.ui
{
    internal class wire_up_the_container : ICommand
    {
        public void run()
        {
            using (new display_the_splash_screen().on_a_background_thread())
            {
                this.log().debug("initializing container");
                var registry = new WindsorDependencyRegistry();
                new wire_up_the_essential_services_into_the(registry)
                    .then(new wire_up_the_mappers_in_to_the(registry))
                    .then(new wire_up_the_views_in_to_the(registry))
                    .then(new wire_up_the_reports_in_to_the(registry))
                    .run();
            }
        }
    }
}