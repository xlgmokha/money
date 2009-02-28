using System.Collections.Generic;
using MyMoney.Presentation.Presenters.billing.dto;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views.billing
{
    public interface IViewAllBills : IDockedContentView
    {
        void display(IEnumerable<bill_information_dto> bills);
    }
}