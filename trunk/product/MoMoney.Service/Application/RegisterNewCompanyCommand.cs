using Gorilla.Commons.Utility.Core;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Presenters.billing.dto;

namespace MoMoney.Tasks.application
{
    public interface IRegisterNewCompanyCommand : IParameterizedCommand<RegisterNewCompany>
    {
    }

    public class RegisterNewCompanyCommand : IRegisterNewCompanyCommand
    {
        readonly ICompanyFactory factory;

        public RegisterNewCompanyCommand(ICompanyFactory factory)
        {
            this.factory = factory;
        }

        public void run(RegisterNewCompany item)
        {
            factory.create().change_name_to(item.company_name);
        }
    }
}