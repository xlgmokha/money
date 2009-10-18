using MoMoney.Presentation.Model.reporting;

namespace MoMoney.Presentation.Views
{
    public interface IReportViewer : IDockedContentView
    {
        void display(IReport report);
    }
}