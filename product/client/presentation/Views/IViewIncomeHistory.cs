using System.Collections.Generic;
using gorilla.commons.utility;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters;
using momoney.presentation.views;

namespace MoMoney.Presentation.Views
{
    public interface IViewIncomeHistory : ITab,
                                          View<ViewIncomeHistoryPresenter>,
                                          Callback<IEnumerable<IncomeInformationDTO>>

    {
    }
}