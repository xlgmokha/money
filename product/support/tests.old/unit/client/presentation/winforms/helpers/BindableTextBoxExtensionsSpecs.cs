using System;
using System.Windows.Forms;
using MoMoney.Presentation.Winforms.Helpers;

namespace tests.unit.client.presentation.winforms.helpers
{
    public class BindableTextBoxExtensionsSpecs
    {
        [Concern(typeof (BindableTextBoxExtensions))]
        public class when_binding_a_text_control_to_a_command : concerns
        {
            it should_run_each_command_when_the_text_changes_in_the_text_control = () => command.was_told_to(x => x.run_against(result));

            context c = () =>
            {
                textbox = new TextBox();
                command = an<ITextBoxCommand<string>>();
            };

            because b = () =>
            {
                result = new TextControl<string>(textbox).apply(command);
                textbox.control_is(x => x.OnLeave(new EventArgs()));
            };

            static TextBox textbox;
            static ITextBoxCommand<string> command;
            static IBindableTextBox<string> result;
        }
    }
}