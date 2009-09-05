using System.Runtime.Serialization;

namespace MoMoney.DTO
{
    [DataContract]
    public class RegisterNewCompany
    {
        [DataMember]
        public string company_name { get; set; }
    }
}