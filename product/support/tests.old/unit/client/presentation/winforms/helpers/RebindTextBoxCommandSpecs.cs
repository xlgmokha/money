using System;
using System.Linq.Expressions;
using MoMoney.Presentation.Winforms.Helpers;

namespace tests.unit.client.presentation.winforms.helpers
{
    public class RebindTextBoxCommandSpecs {}

    [Concern(typeof (RebindTextBoxCommand<>))]
    public class when_the_text_in_a_textbox_changes :
        TestsFor<ITextBoxCommand<string>>
    {
        context c = () =>
        {
            textbox = an<IBindableTextBox<string>>();
            binder = x => "";
        };

        public override ITextBoxCommand<string> create_sut()
        {
            return new RebindTextBoxCommand<string>(binder);
        }

        static protected IBindableTextBox<string> textbox;
        static protected Expression<Func<string, string>> binder;
    }

    [Concern(typeof (RebindTextBoxCommand<>))]
    public class when_rebinding_an_item_to_a_textbox : when_the_text_in_a_textbox_changes
    {
        it should_bind_the_text_control_to_the_new_item = () => textbox.was_told_to(x => x.bind_to("kat"));

        context c = () =>
        {
            binder = x => "kat";
            textbox.is_told_to(x => x.text()).it_will_return("kitty");
        };

        because b = () => sut.run_against(textbox);
    }
}