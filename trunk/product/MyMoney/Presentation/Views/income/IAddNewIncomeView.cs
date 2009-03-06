using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Model.interaction;
using MoMoney.Presentation.Presenters.income;
using MoMoney.Presentation.Presenters.income.dto;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.income
{
    public interface IAddNewIncomeView : IDockedContentView, IView<IAddNewIncomePresenter>, INotification
    {
        void display(IEnumerable<ICompany> companys);
        void display(IEnumerable<income_information_dto> incomes);
    }
}