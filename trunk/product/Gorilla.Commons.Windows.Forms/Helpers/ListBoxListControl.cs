using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public class ListBoxListControl<ItemToStore> : IListControl<ItemToStore>
    {
        readonly ListBox list_box;

        public ListBoxListControl(ListBox list_box)
        {
            this.list_box = list_box;
        }

        public ItemToStore get_selected_item()
        {
            return (ItemToStore) list_box.SelectedItem;
        }

        public void add_item(ItemToStore item)
        {
            list_box.Items.Add(item);
        }

        public void set_selected_item(ItemToStore item)
        {
            if (list_box.Items.Contains(item))
            {
                list_box.SelectedItem = item;
            }
        }
    }
}