using System.Windows.Forms;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
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