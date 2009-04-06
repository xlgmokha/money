using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.repositories;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Utility.Core;

namespace MoMoney.Tasks.application
{
    public interface IRegisterNewCompanyCommand : IParameterizedCommand<RegisterNewCompany>
    {
    }

    public class RegisterNewCompanyCommand : IRegisterNewCompanyCommand
    {
        readonly ICompanyRepository companys;

        public RegisterNewCompanyCommand(ICompanyRepository companys)
        {
            this.companys = companys;
        }

        public void run(RegisterNewCompany item)
        {
            companys.save(new Company(item.company_name));
        }
    }
}