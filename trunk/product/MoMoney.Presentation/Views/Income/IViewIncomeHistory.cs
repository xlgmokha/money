using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using MoMoney.Presentation.Presenters.income;
using MoMoney.Presentation.Presenters.income.dto;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.income
{
    public interface IViewIncomeHistory : IDockedContentView,
                                          IView<IViewIncomeHistoryPresenter>,
                                          ICallback<IEnumerable<IncomeInformationDTO>>

    {
    }
}