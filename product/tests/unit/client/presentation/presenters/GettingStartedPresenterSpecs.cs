using developwithpassion.bdd.contexts;
using momoney.presentation.presenters;
using momoney.presentation.views;

namespace tests.unit.client.presentation.presenters
{
    public class GettingStartedPresenterSpecs
    {
        public class behaves_like_the_getting_started_presenter : concerns_for<GettingStartedPresenter>
        {
            context c = () =>
            {
                view = the_dependency<IGettingStartedView>();
            };

            static protected IGettingStartedView view;
        }

        public class when_a_new_project_is_opened : behaves_like_the_getting_started_presenter
        {
            it should_display_the_getting_started_screen = () => shell.was_told_to(x => x.add(view));

            context c = () =>
            {
                shell = an<Shell>();
            };

            because b = () => sut.present(shell);
            static Shell shell;
        }
    }
}