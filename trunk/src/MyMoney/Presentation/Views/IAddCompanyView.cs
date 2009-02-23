using System.Collections.Generic;
using MyMoney.Domain.accounting.billing;
using MyMoney.Presentation.Model.interaction;
using MyMoney.Presentation.Presenters;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views
{
    public interface IAddCompanyView : IDockedContentView, INotification, IView<IAddCompanyPresenter>
    {
        void display(IEnumerable<ICompany> companies);
    }
}