using System.Collections.Generic;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Views
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