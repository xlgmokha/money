using System;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.Presentation.Presenters.excel
{
    public class Cell
    {
        public static ISpecification<ICell> occurs_between_columns(int left_column, int right_column)
        {
            throw new NotImplementedException();
        }

        public static ISpecification<ICell> occurs_after_row(int row_number)
        {
            throw new NotImplementedException();
        }

        public static ISpecification<ICell> is_named(string name_of_the_cell)
        {
            throw new NotImplementedException();
        }
    }
}