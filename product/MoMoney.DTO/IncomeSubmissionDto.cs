using System;
using System.Runtime.Serialization;

namespace MoMoney.DTO
{
    [DataContract]
    public class IncomeSubmissionDto
    {
        [DataMember]
        public Guid company_id { get; set; }

        [DataMember]
        public double amount { get; set; }

        [DataMember]
        public DateTime recieved_date { get; set; }
    }
}