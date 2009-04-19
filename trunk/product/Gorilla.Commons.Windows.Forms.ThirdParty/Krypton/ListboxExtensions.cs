using System.Collections.Generic;
using ComponentFactory.Krypton.Toolkit;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.Presentation.Databindings
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