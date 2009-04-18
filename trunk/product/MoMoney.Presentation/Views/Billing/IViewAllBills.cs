using System.Collections.Generic;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.billing
{
    public interface IViewAllBills : IDockedContentView
    {
        void display(IEnumerable<BillInformationDTO> bills);
    }
}