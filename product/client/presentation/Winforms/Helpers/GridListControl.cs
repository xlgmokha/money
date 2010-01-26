using System;
using System.Windows.Forms;

namespace MoMoney.Presentation.Winforms.Helpers
{
    public class GridListControl<T> : IListControl<T>
    {
        DataGrid grid;

        public GridListControl(DataGrid grid)
        {
            this.grid = grid;
        }

        public T get_selected_item()
        {
            //grid.
            return default(T);
        }

        public void add_item(T item)
        {
        }

        public void set_selected_item(T item)
        {
            throw new NotImplementedException();
        }
    }
}