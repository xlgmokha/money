using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters.billing;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.Core;

namespace MoMoney.Presentation.Views.billing
{
    public interface IAddBillPaymentView : IDockedContentView,
                                           IView<IAddBillPaymentPresenter>,
                                           ICallback<IEnumerable<CompanyDTO>>,
                                           ICallback<IEnumerable<BillInformationDTO>>
    {
    }
}