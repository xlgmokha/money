using System.Drawing;

namespace MoMoney.Presentation.Model.Excel
{
    public interface ICellInterior
    {
        Color Color { get; set; }
        int FontSize { get; set; }
    }
}