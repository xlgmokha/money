using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using MoMoney.Presentation.Presenters.billing;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.Core;

namespace MoMoney.Presentation.Views.billing
{
    public interface IViewAllBills : IDockedContentView,
                                     IView<IViewAllBillsPresenter>,
                                     ICallback<IEnumerable<BillInformationDTO>>
    {
    }
}