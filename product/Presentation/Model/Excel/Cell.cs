using System;
using gorilla.commons.utility;

namespace MoMoney.Presentation.Model.Excel
{
    public class Cell
    {
        static public Specification<ICell> occurs_between_columns(int left_column, int right_column)
        {
            throw new NotImplementedException();
        }

        static public Specification<ICell> occurs_after_row(int row_number)
        {
            throw new NotImplementedException();
        }

        static public Specification<ICell> is_named(string name_of_the_cell)
        {
            throw new NotImplementedException();
        }
    }
}