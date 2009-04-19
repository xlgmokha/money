using System.Collections.Generic;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
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
}