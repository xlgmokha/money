using System.Drawing;

namespace MoMoney.Presentation.Presenters.excel
{
    public interface ICellInterior
    {
        Color Color { get; set; }
        int FontSize { get; set; }
    }
}