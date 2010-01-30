using MoMoney.Presentation.Model.reporting;
using momoney.presentation.views;

namespace MoMoney.Presentation.Views
{
    public interface IReportViewer : ITab
    {
        void display(IReport report);
    }
}