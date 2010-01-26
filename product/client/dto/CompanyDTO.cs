using System;
using System.Runtime.Serialization;

namespace MoMoney.DTO
{
    [DataContract]
    public class CompanyDTO
    {
        [DataMember]
        public Guid id { get; set; }

        [DataMember]
        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}