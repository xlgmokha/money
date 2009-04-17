using System;

namespace MoMoney.Presentation.Presenters.income.dto
{
    public class IncomeSubmissionDto
    {
        public Guid company_id;
        public double amount { get; set; }
        public DateTime recieved_date { get; set; }
    }
}