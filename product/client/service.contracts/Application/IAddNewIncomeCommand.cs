using System.ServiceModel;
using gorilla.commons.utility;
using MoMoney.DTO;

namespace MoMoney.Service.Contracts.Application
{
    [ServiceContract]
    public interface IAddNewIncomeCommand : ParameterizedCommand<IncomeSubmissionDTO> {}
}