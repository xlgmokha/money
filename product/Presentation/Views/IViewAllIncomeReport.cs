using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Model.reporting;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Presentation.Views
{
    public interface IViewAllIncomeReport : IBindReportTo<IEnumerable<IncomeInformationDTO>, IGetAllIncomeQuery>
    {
    }
}