using System;
using System.Runtime.Serialization;

namespace MoMoney.DTO
{
    [DataContract]
    public class BillInformationDTO
    {
        [DataMember]
        public string company_name { get; set; }

        [DataMember]
        public string the_amount_owed { get; set; }

        [DataMember]
        public DateTime due_date { get; set; }
    }
}