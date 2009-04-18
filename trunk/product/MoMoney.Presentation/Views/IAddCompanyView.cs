using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Model.interaction;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views
{
    public interface IAddCompanyView : IDockedContentView, INotification, IView<IAddCompanyPresenter>, ICallback<IEnumerable<ICompany>>
    {
        //void run(IEnumerable<ICompany> companies);
    }
}