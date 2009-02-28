using System.Collections.Generic;
using MyMoney.Domain.accounting.billing;
using MyMoney.Presentation.Model.interaction;
using MyMoney.Presentation.Presenters.income;
using MyMoney.Presentation.Presenters.income.dto;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views.income
{
    public interface IAddNewIncomeView : IDockedContentView, IView<IAddNewIncomePresenter>, INotification
    {
        void display(IEnumerable<ICompany> companys);
        void display(IEnumerable<income_information_dto> incomes);
    }
}