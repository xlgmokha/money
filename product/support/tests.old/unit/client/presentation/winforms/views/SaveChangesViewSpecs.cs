using System;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Winforms.Helpers;
using MoMoney.Presentation.Winforms.Views;

namespace tests.unit.client.presentation.winforms.views
{
    [Concern(typeof (SaveChangesView))]
    public class when_prompted_to_save_changes_to_the_project : tests_for<SaveChangesView>
    {
        context c = () =>
        {
            presenter = an<SaveChangesPresenter>();
        };

        after_the_sut_has_been_created after = () =>
        {
            save_changes_window = sut;
            save_changes_window.attach_to(presenter);
        };

        static protected SaveChangesPresenter presenter;
        static protected SaveChangesView save_changes_window;
    }

    public class when_the_save_button_is_pressed : when_prompted_to_save_changes_to_the_project
    {
        it should_save_the_current_project = () => presenter.was_told_to(x => x.save());

        because b = () => save_changes_window.save_button.control_is(x => x.OnClick(new EventArgs()));
    }

    public class when_the_cancel_button_is_pressed : when_prompted_to_save_changes_to_the_project
    {
        it should_not_continue_processing_the_previous_action = () => presenter.was_told_to(x => x.cancel());

        because b = () => save_changes_window.cancel_button.control_is(x => x.OnClick(new EventArgs()));
    }

    public class when_the_do_not_save_button_is_pressed : when_prompted_to_save_changes_to_the_project
    {
        it should_not_save_the_project = () => presenter.was_told_to(x => x.dont_save());

        because b = () => save_changes_window.do_not_save_button.control_is(x => x.OnClick(new EventArgs()));
    }
}