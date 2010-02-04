using System.Collections.Generic;

namespace MoMoney.Presentation.Winforms.Helpers
{
    public interface IBindableList<ItemToBindTo>
    {
        void bind_to(IEnumerable<ItemToBindTo> items);
        ItemToBindTo get_selected_item();
        void set_selected_item(ItemToBindTo item);
    }
}