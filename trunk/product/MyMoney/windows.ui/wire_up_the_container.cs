using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Infrastructure.Threading;
using MoMoney.Presentation.Model.interaction;
using MoMoney.Presentation.Presenters.Startup;
using MoMoney.Presentation.Views.Startup;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;
using display_the_splash_screen=MoMoney.Presentation.Presenters.Commands.display_the_splash_screen;

namespace MoMoney.windows.ui
{
    internal class wire_up_the_container : ICommand
    {
        public void run()
        {
            var presenter = get_presenter();
            using (new display_the_splash_screen(presenter).on_a_background_thread())
            {
                var registry = get_registry(presenter);
                new wire_up_the_core_services_into_the(registry)
                    .then(new wire_up_the_mappers_in_to_the(registry))
                    .then(new wire_up_the_views_in_to_the(registry))
                    .then(new wire_up_the_reports_in_to_the(registry))
                    .run();
            }
        }

        ISplashScreenPresenter get_presenter()
        {
            return new SplashScreenPresenter(new IntervalTimer(new TimerFactory()), new SplashScreenView());
        }

        WindsorDependencyRegistry get_registry(ICallback<notification_message> callback)
        {
            return get_the.registry(callback);
        }
    }
}