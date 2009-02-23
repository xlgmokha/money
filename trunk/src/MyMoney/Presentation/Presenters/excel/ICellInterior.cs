using System.Drawing;

namespace MyMoney.Presentation.Presenters.excel
{
    public interface ICellInterior
    {
        Color Color { get; set; }
        int FontSize { get; set; }
    }
}