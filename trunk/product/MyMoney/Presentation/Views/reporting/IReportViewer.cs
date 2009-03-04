using MyMoney.Presentation.Model.reporting;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views.reporting
{
    public interface IReportViewer : IDockedContentView
    {
        void display(IReport report);
    }
}