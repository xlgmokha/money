using System.Collections.Generic;
using Gorilla.Commons.Utility.Core;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters;

namespace MoMoney.Presentation.Views
{
    public interface IViewAllBills : IDockedContentView,
                                     IView<IViewAllBillsPresenter>,
                                     ICallback<IEnumerable<BillInformationDTO>>
    {
    }
}