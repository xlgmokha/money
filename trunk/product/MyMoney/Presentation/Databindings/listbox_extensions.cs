using System.Collections.Generic;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Databindings
{
    public static class listbox_extensions
    {
        public static void bind_to<T>(this ComboBox control, IEnumerable<T> items)
        {
            items.each(x => control.Items.Add(x));
        }

        public static void bind_to<T>(this KryptonComboBox control, IEnumerable<T> items)
        {
            items.each(x => control.Items.Add(x));
        }
    }
}