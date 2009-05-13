using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters.income;
using MoMoney.Presentation.Views.Core;

namespace MoMoney.Presentation.Views.income
{
    public interface IViewIncomeHistory : IDockedContentView,
                                          IView<IViewIncomeHistoryPresenter>,
                                          ICallback<IEnumerable<IncomeInformationDTO>>

    {
    }
}