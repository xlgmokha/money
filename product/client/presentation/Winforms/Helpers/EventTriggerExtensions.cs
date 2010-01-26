using System;
using System.Linq.Expressions;

namespace MoMoney.Presentation.Winforms.Helpers
{
    public static class EventTriggerExtensions
    {
        public static void control_is<Control>(this Control target, Expression<Action<Events.ControlEvents>> expression)
            where Control : System.Windows.Forms.Control
        {
            EventTrigger.trigger_event(expression, target);
        }
    }
}