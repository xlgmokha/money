using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using MoMoney.DTO;
using MoMoney.Presentation.Model.interaction;
using MoMoney.Presentation.Presenters.income;
using MoMoney.Presentation.Presenters.income.dto;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.income
{
    public interface IAddNewIncomeView : IDockedContentView, IView<IAddNewIncomePresenter>, INotification,
                                         ICallback<IEnumerable<CompanyDTO>>,
                                         ICallback<IEnumerable<IncomeInformationDTO>>
    {
    }
}