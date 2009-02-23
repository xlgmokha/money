using System;

namespace MyMoney.Presentation.Presenters.billing.dto
{
    public class bill_information_dto
    {
        public string company_name { get; set; }
        public string the_amount_owed { get; set; }
        public DateTime due_date { get; set; }
    }
}