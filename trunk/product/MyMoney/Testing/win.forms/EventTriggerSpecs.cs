using System;
using System.Windows.Forms;
using jpboodhoo.bdd.contexts;
using MbUnit.Framework;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Testing.win.forms
{
    [Ignore]
    public class when_invoking_a_call_on_a_target_via_reflection : concerns_for
    {
        it should_correctly_call_that_method = () =>
                                                   {
                                                       control.key_press_arguments.should_be_equal_to(new KeyPressEventArgs('A'));
                                                       control.called_on_key_press.should_be_true();
                                                       control.called_on_enter.should_be_false();
                                                   };

        context c = () => { control = new TestControl(); };

        because b = () => EventTrigger.trigger_event<Events.ControlEvents>(x => x.OnKeyPress(new KeyPressEventArgs('A')), control);

        static TestControl control;

        //static readonly KeyPressEventArgs args = new KeyPressEventArgs('A');
    }

    internal class TestControl
    {
        public bool called_on_enter;
        public bool called_on_key_press;
        public KeyPressEventArgs key_press_arguments;

        protected void OnEnter(EventArgs args)
        {
            called_on_enter = true;
        }

        protected void OnKeyPress(KeyPressEventArgs args)
        {
            called_on_key_press = true;
            key_press_arguments = args;
        }
    }
}