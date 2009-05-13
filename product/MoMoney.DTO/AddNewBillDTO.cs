using System;
using System.Runtime.Serialization;

namespace MoMoney.DTO
{
    [DataContract]
    public class AddNewBillDTO
    {
        [DataMember]
        public Guid company_id { get; set; }

        [DataMember]
        public DateTime due_date { get; set; }

        [DataMember]
        public double total { get; set; }
    }
}