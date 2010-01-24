using System.Windows.Forms;

namespace MoMoney.Presentation.Winforms.Helpers
{
    public class ListViewControl<T> : IListControl<T>
    {
        ListView control;

        public ListViewControl(ListView control)
        {
            this.control = control;
        }

        public T get_selected_item()
        {
            //return control.SelectedItems.First();
            return default(T);
        }

        public void add_item(T item)
        {
            control.Items.Add(new ListViewItem(item.ToString()) {Tag = item});
        }

        public void set_selected_item(T item)
        {
            //control.SelectedItems
        }
    }
}