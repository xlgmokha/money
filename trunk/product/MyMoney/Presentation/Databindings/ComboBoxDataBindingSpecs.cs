using System.Windows.Forms;
using jpboodhoo.bdd.contexts;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;
using mocking_extensions=MoMoney.Testing.spechelpers.core.mocking_extensions;

namespace MoMoney.Presentation.Databindings
{
    [Concern(typeof (Create))]
    public class when_binding_a_property_from_an_object_to_a_combo_box : concerns_for
    {
        it should_initialize_the_combo_box_with_the_current_value_of_the_property =
            () => combo_box.SelectedItem.should_be_equal_to(baby_girl);

        context c = () =>
                        {
                            combo_box = new ComboBox();
                            thing_to_bind_to = an<IAnInterface>();
                            baby_girl = an<IAnInterface>();
                            baby_boy = an<IAnInterface>();

                            combo_box.Items.Add(baby_boy);
                            combo_box.Items.Add(baby_girl);

                            mocking_extensions.it_will_return(mocking_extensions.is_asked_for(when_the(thing_to_bind_to), t => t.Child), baby_girl);
                        };

        because b = () => Create
                              .binding_for(thing_to_bind_to)
                              .bind_to_property(t => t.Child)
                              .bound_to_control(combo_box);

        static ComboBox combo_box;
        static IAnInterface thing_to_bind_to;
        static IAnInterface baby_girl;
        static IAnInterface baby_boy;
    }

    [Concern(typeof (Create))]
    public class when_changing_the_selected_item_on_a_combo_box_that_is_bound_to_a_property : concerns_for
    {
        it should_change_the_value_of_the_property_that_the_combo_box_is_bound_to =
            () => thing_to_bind_to.Child.should_be_equal_to(baby_boy);

        context c = () =>
                        {
                            combo_box = new ComboBox();
                            baby_girl = an<IAnInterface>();
                            baby_boy = an<IAnInterface>();
                            thing_to_bind_to = new AnImplementation {Child = baby_girl};

                            combo_box.Items.Add(baby_boy);
                            combo_box.Items.Add(baby_girl);

                            Create
                                .binding_for(thing_to_bind_to)
                                .bind_to_property(t => t.Child)
                                .bound_to_control(combo_box);
                        };

        because b = () => { combo_box.SelectedItem = baby_boy; };

        static ComboBox combo_box;
        static IAnInterface thing_to_bind_to;
        static IAnInterface baby_girl;
        static IAnInterface baby_boy;
    }
}