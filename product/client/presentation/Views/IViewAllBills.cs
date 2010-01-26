using System.Collections.Generic;
using gorilla.commons.utility;
using MoMoney.DTO;
using momoney.presentation.presenters;
using momoney.presentation.views;

namespace MoMoney.Presentation.Views
{
    public interface IViewAllBills : IDockedContentView,
                                     IView<ViewAllBillsPresenter>,
                                     Callback<IEnumerable<BillInformationDTO>>
    {
    }
}