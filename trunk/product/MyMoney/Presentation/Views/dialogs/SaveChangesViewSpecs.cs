using System;
using developwithpassion.bdd.contexts;
using MoMoney.Presentation.Model.Menu.File.Commands;
using MoMoney.Presentation.Views.helpers;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Views.dialogs
{
    public class behaves_like_save_changes_view_bound_to_presenter : concerns_for<SaveChangesView>
    {
        context c = () => { presenter = an<ISaveChangesPresenter>(); };

        because b = () => sut.attach_to(presenter);

        static protected ISaveChangesPresenter presenter;
    }

    public class when_the_save_button_is_clicked : behaves_like_save_changes_view_bound_to_presenter
    {
        it should_forward_the_call_to_the_presenter = () => presenter.was_told_to(x => x.save());

        because b =
            () => EventTrigger.trigger_event<Events.ControlEvents>(x => x.OnClick(new EventArgs()), sut.ux_save_button);
    }

    public class when_the_cancel_button_is_clicked : behaves_like_save_changes_view_bound_to_presenter
    {
        it should_forward_the_call_to_the_presenter = () => presenter.was_told_to(x => x.cancel());

        because b =
            () =>
            EventTrigger.trigger_event<Events.ControlEvents>(x => x.OnClick(new EventArgs()), sut.ux_cancel_button);
    }

    public class when_the_do_not_save_button_is_clicked : behaves_like_save_changes_view_bound_to_presenter
    {
        it should_forward_the_call_to_the_presenter = () => presenter.was_told_to(x => x.dont_save());

        because b =
            () =>
            EventTrigger.trigger_event<Events.ControlEvents>(x => x.OnClick(new EventArgs()), sut.ux_do_not_save_button);
    }
}