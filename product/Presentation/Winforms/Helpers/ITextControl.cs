using System;

namespace MoMoney.Presentation.Winforms.Helpers
{
    public interface ITextControl<ItemToStore>
    {
        void set_selected_item(ItemToStore item);
        ItemToStore get_selected_item();
        string text();
        Action when_text_is_changed { get; set; }
    }
}