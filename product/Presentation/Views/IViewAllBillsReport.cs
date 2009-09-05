using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Model.reporting;

namespace MoMoney.Presentation.Views.billing
{
    public interface IViewAllBillsReport : IReport
    {
        void run(IEnumerable<BillInformationDTO> bills);
    }
}