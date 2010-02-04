namespace MoMoney.Presentation.Winforms.Helpers
{
    public interface IListControl<ItemToStore>
    {
        ItemToStore get_selected_item();
        void add_item(ItemToStore item);
        void set_selected_item(ItemToStore item);
    }
}