using System.Collections.Generic;
using ComponentFactory.Krypton.Toolkit;
using gorilla.commons.utility;

namespace MoMoney.Presentation.Winforms.Krypton
{
    static public class ListboxExtensions
    {
        static public void bind_to<T>(this KryptonComboBox control, IEnumerable<T> items)
        {
            control.Items.Clear();
            items.each(x => control.Items.Add(x));
        }
    }
}