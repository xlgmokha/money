using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Presenters.billing;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.billing
{
    public interface IAddBillPaymentView : IDockedContentView, IView<IAddBillPaymentPresenter>
    {
        void display(IEnumerable<ICompany> companys);
        void display(IEnumerable<bill_information_dto> bills);
    }
}