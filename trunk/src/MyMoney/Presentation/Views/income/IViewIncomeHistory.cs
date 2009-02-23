using System.Collections.Generic;
using MyMoney.Presentation.Presenters.income.dto;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views.income
{
    public interface IViewIncomeHistory : IDockedContentView
    {
        void display(IEnumerable<income_information_dto> summary);
    }
}