using System.Collections.Generic;
using gorilla.commons.utility;
using MoMoney.DTO;
using momoney.presentation.presenters;

namespace momoney.presentation.views
{
    public interface IAddBillPaymentView : IDockedContentView,
                                           IView<AddBillPaymentPresenter>,
                                           Callback<IEnumerable<CompanyDTO>>,
                                           Callback<IEnumerable<BillInformationDTO>> {}
}