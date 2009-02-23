using System.Collections.Generic;
using MyMoney.Domain.accounting.billing;
using MyMoney.Presentation.Presenters.billing;
using MyMoney.Presentation.Presenters.billing.dto;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views.billing
{
    public interface IAddBillPaymentView : IDockedContentView, IView<IAddBillPaymentPresenter>
    {
        void display(IEnumerable<ICompany> companys);
        void display(IEnumerable<bill_information_dto> bills);
    }
}