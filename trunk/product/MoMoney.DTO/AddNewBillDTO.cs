using System;

namespace MoMoney.DTO
{
    public class AddNewBillDTO
    {
        public Guid company_id { get; set; }
        public DateTime due_date { get; set; }
        public double total { get; set; }
    }
}