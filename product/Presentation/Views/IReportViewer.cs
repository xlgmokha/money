using MoMoney.Presentation.Model.reporting;
using MoMoney.Presentation.Views.Core;

namespace MoMoney.Presentation.Views
{
    public interface IReportViewer : IDockedContentView
    {
        void display(IReport report);
    }
}