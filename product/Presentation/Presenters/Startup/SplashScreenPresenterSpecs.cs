using System;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Threading;
using Gorilla.Commons.Testing;
using MoMoney.Presentation.Views.Startup;

namespace MoMoney.Presentation.Presenters.Startup
{
    [Concern(typeof (SplashScreenPresenter))]
    public abstract class behaves_like_splash_screen_presenter : concerns_for<ISplashScreenPresenter>
    {
        public override ISplashScreenPresenter create_sut()
        {
            return new SplashScreenPresenter(timer, view);
        }

        context c = () =>
                        {
                            timer = the_dependency<ITimer>();
                            view = the_dependency<ISplashScreenView>();
                        };

        protected static ITimer timer;
        protected static ISplashScreenView view;
    }

    public class when_displaying_the_splash_screen : behaves_like_splash_screen_presenter
    {
        it should_start_a_timer_that_increments_the_opacity =
            () => timer.was_told_to(t => t.start_notifying(sut, new TimeSpan(50)));

        it should_show_the_splash_screen = () => view.was_told_to(v => v.display());

        because b = () => sut.run();
    }

    public class when_the_timer_notifies_the_presenter_that_to_update : behaves_like_splash_screen_presenter
    {
        it should_increment_the_views_opacity = () => view.was_told_to(v => v.increment_the_opacity());

        context c = () => when_the(view).is_asked_for(v => v.current_opacity()).it_will_return(0.5);

        because b = () =>
                        {
                            sut.run();
                            sut.notify();
                        };
    }

    public class when_the_timer_notifies_the_presenter_to_update_and_the_opacity_of_the_view_has_reached_100_percent :
        behaves_like_splash_screen_presenter
    {
        it should_stop_the_timer = () => timer.was_told_to(t => t.stop_notifying(sut));

        context c = () => when_the(view).is_asked_for(v => v.current_opacity()).it_will_return(1);

        because b = () =>
                        {
                            sut.run();
                            sut.notify();
                        };
    }

    public class when_hiding_the_splash_screen : behaves_like_splash_screen_presenter
    {
        it should_start_a_timer_to_fade_the_splash_screen_away =
            () => timer.was_told_to(t => t.start_notifying(sut, new TimeSpan(50)));

        it should_decrement_the_opacity_of_the_view = () => view.was_told_to(v => v.decrement_the_opacity());

        context c = () => when_the(view).is_asked_for(v => v.current_opacity()).it_will_return(.5);

        because b = () =>
                        {
                            sut.Dispose();
                            sut.notify();
                        };
    }

    public class when_the_splash_screen_is_fading_away_and_its_opacity_has_reached_zero :
        behaves_like_splash_screen_presenter
    {
        it should_stop_the_timer = () => timer.was_told_to(t => t.stop_notifying(sut));

        it should_close_the_view = () => view.was_told_to(v => v.close_the_screen());

        context c = () => when_the(view).is_asked_for(v => v.current_opacity()).it_will_return(0);

        because b = () =>
                        {
                            sut.Dispose();
                            sut.notify();
                        };
    }
}