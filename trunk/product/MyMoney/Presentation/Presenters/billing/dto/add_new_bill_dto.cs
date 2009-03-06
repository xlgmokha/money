using System;

namespace MoMoney.Presentation.Presenters.billing.dto
{
    public class add_new_bill_dto
    {
        public string company_name { get; set; }
        public DateTime due_date { get; set; }
        public double total { get; set; }
    }
}