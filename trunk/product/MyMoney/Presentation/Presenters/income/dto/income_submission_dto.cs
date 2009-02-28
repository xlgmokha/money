using System;
using MyMoney.Domain.accounting.billing;

namespace MyMoney.Presentation.Presenters.income.dto
{
    public class income_submission_dto
    {
        public ICompany company { get; set; }
        public double amount { get; set; }
        public DateTime recieved_date { get; set; }
    }
}