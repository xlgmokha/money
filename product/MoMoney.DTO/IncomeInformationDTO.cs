using System.Runtime.Serialization;

namespace MoMoney.DTO
{
    [DataContract]
    public class IncomeInformationDTO
    {
        [DataMember]
        public string company { get; set; }

        [DataMember]
        public string amount { get; set; }

        [DataMember]
        public string recieved_date { get; set; }
    }
}