using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Model.interaction;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Views.core;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Views
{
    public interface IAddCompanyView : IDockedContentView, INotification, IView<IAddCompanyPresenter>, ICallback<IEnumerable<ICompany>>
    {
        //void run(IEnumerable<ICompany> companies);
    }
}