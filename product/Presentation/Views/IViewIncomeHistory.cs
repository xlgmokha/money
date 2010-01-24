using System.Collections.Generic;
using gorilla.commons.utility;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters;
using momoney.presentation.views;

namespace MoMoney.Presentation.Views
{
    public interface IViewIncomeHistory : IDockedContentView,
                                          IView<ViewIncomeHistoryPresenter>,
                                          Callback<IEnumerable<IncomeInformationDTO>>

    {
    }
}