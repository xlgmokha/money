namespace MoMoney.Presentation.Winforms.Helpers
{
    static public class BindableListFactory
    {
        static public IBindableList<TItemToBindTo> create_for<TItemToBindTo>(IListControl<TItemToBindTo> list_control)
        {
            return new BindableListBox<TItemToBindTo>(list_control);
        }
    }
}