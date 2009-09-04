using System.Runtime.Serialization;

namespace MoMoney.DTO
{
    [DataContract]
    public class MonthlySummaryDTO
    {
        [DataMember]
        public string month { get; set; }

        [DataMember]
        public double income { get; set; }

        [DataMember]
        public double expenses { get; set; }

        [DataMember]
        public double summary { get; set; }
    }
}