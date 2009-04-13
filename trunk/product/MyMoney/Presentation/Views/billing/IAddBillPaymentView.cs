using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Presenters.billing;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.core;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Views.billing
{
    public interface IAddBillPaymentView : IDockedContentView,
                                           IView<IAddBillPaymentPresenter>,
                                           ICallback<IEnumerable<ICompany>>,
                                           ICallback<IEnumerable<bill_information_dto>>
    {
    }
}