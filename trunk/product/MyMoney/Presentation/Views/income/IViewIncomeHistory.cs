using System.Collections.Generic;
using MoMoney.Presentation.Presenters.income.dto;
using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.income
{
    public interface IViewIncomeHistory : IDockedContentView
    {
        void display(IEnumerable<income_information_dto> summary);
    }
}