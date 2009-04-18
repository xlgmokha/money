using System.Collections.Generic;
using System.Windows.Forms;

namespace MoMoney.Presentation.Views.helpers
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

    public interface IBindableList<ItemToBindTo>
    {
        void bind_to(IEnumerable<ItemToBindTo> items);
        ItemToBindTo get_selected_item();
        void set_selected_item(ItemToBindTo item);
    }

    public interface IListControl<ItemToStore>
    {
        ItemToStore get_selected_item();
        void add_item(ItemToStore item);
        void set_selected_item(ItemToStore item);
    }

    public class BindableListBox<ItemToBindTo> : IBindableList<ItemToBindTo>
    {
        readonly IListControl<ItemToBindTo> listControl;

        public BindableListBox(IListControl<ItemToBindTo> listControl)
        {
            this.listControl = listControl;
        }

        public void bind_to(IEnumerable<ItemToBindTo> items)
        {
            foreach (var item in items)
            {
                listControl.add_item(item);
            }
        }

        public ItemToBindTo get_selected_item()
        {
            return listControl.get_selected_item();
        }

        public void set_selected_item(ItemToBindTo item)
        {
            listControl.set_selected_item(item);
        }
    }

    public class ListBoxListControl<ItemToStore> : IListControl<ItemToStore>
    {
        readonly ListBox _listBox;

        public ListBoxListControl(ListBox listBox)
        {
            _listBox = listBox;
        }

        public ItemToStore get_selected_item()
        {
            return (ItemToStore) _listBox.SelectedItem;
        }

        public void add_item(ItemToStore item)
        {
            _listBox.Items.Add(item);
        }

        public void set_selected_item(ItemToStore item)
        {
            if (_listBox.Items.Contains(item))
            {
                _listBox.SelectedItem = item;
            }
        }
    }

    public class ComboBoxListControl<ItemToStore> : IListControl<ItemToStore>
    {
        readonly ComboBox combo_box;

        public ComboBoxListControl(ComboBox combo_box)
        {
            this.combo_box = combo_box;
        }

        public ItemToStore get_selected_item()
        {
            return (ItemToStore) combo_box.SelectedItem;
        }

        public void add_item(ItemToStore item)
        {
            combo_box.Items.Add(item);
            combo_box.SelectedIndex = 0;
        }

        public void set_selected_item(ItemToStore item)
        {
            if (!Equals(item, default(ItemToStore)))
            {
                if (combo_box.Items.Contains(item))
                {
                    combo_box.SelectedItem = item;
                }
            }
        }
    }
}