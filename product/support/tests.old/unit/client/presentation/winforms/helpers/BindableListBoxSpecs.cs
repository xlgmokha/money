using System.Collections.Generic;
using MoMoney.Presentation.Winforms.Helpers;

namespace tests.unit.client.presentation.winforms.helpers
{
    public class BindableListBoxSpecs {}

    [Concern(typeof (BindableListBox<>))]
    public class behaves_like_bindable_list : runner<BindableListBox<string>>
    {
        context c = () =>
        {
            control = dependency<IListControl<string>>();
        };

        static protected IListControl<string> control;
    }

    [Concern(typeof (BindableListBox<>))]
    public class when_binding_a_bunch_of_items_to_a_list_control : behaves_like_bindable_list
    {
        it should_add_each_item_to_the_list_control = () =>
        {
            control.was_told_to(x => x.add_item("timone"));
            control.was_told_to(x => x.add_item("pumba"));
        };

        because b = () => sut.bind_to(new List<string> {"timone", "pumba",});
    }

    [Concern(typeof (BindableListBox<>))]
    public class when_assigning_the_selected_item_of_a_list_control : behaves_like_bindable_list
    {
        it should_tell_the_list_control_to_select_that_item =
            () => control.was_told_to(x => x.set_selected_item("arthur"));

        because b = () => sut.set_selected_item("arthur");
    }

    [Concern(typeof (BindableListBox<>))]
    public class when_getting_the_selected_item_from_a_list_control : behaves_like_bindable_list
    {
        it should_return_the_selected_item = () => result.should_be_equal_to("curious george");
        context c = () => control.is_told_to(x => x.get_selected_item()).it_will_return("curious george");

        because b = () =>
        {
            result = sut.get_selected_item();
        };

        static string result;
    }
}