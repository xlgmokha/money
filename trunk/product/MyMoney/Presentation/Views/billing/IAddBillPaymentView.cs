using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Presenters.billing;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.billing
{
    public interface IAddBillPaymentView : IDockedContentView,
                                           IView<IAddBillPaymentPresenter>,
                                           ICallback<IEnumerable<ICompany>>,
                                           ICallback<IEnumerable<BillInformationDTO>>
    {
    }
}