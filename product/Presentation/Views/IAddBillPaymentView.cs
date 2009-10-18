using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters;

namespace MoMoney.Presentation.Views
{
    public interface IAddBillPaymentView : IDockedContentView,
                                           IView<IAddBillPaymentPresenter>,
                                           ICallback<IEnumerable<CompanyDTO>>,
                                           ICallback<IEnumerable<BillInformationDTO>>
    {
    }
}