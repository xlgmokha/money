using System;

namespace MoMoney.Presentation.Presenters.billing.dto
{
    public class BillInformationDTO
    {
        public string company_name { get; set; }
        public string the_amount_owed { get; set; }
        public DateTime due_date { get; set; }
    }
}