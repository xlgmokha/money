using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    static public class BindableListFactory
    {
        static public IBindableList<ItemToBindTo> create_for<ItemToBindTo>(ListBox listbox)
        {
            return new BindableListBox<ItemToBindTo>(new ListBoxListControl<ItemToBindTo>(listbox));
        }

        static public IBindableList<ItemToBindTo> create_for<ItemToBindTo>(ComboBox combobox)
        {
            return new BindableListBox<ItemToBindTo>(new ComboBoxListControl<ItemToBindTo>(combobox));
        }
    }
}