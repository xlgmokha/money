using System.Linq;
using gorilla.commons.utility;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.repositories;
using MoMoney.DTO;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Service.Application
{
    public class RegisterNewCompanyCommand : IRegisterNewCompanyCommand
    {
        readonly ICompanyFactory factory;
        readonly Notification notification;
        readonly ICompanyRepository companies;

        public RegisterNewCompanyCommand(ICompanyFactory factory, Notification notification, ICompanyRepository companies)
        {
            this.factory = factory;
            this.notification = notification;
            this.companies = companies;
        }

        public void run_against(RegisterNewCompany item)
        {
            if (is_there_a_company_registered_with(item.company_name))
                notification.notify(create_error_message_from(item));
            else
            {
                factory.create().change_name_to(item.company_name);
            }
        }

        bool is_there_a_company_registered_with(string company_name)
        {
            return companies.all().Any(x => x.name.is_equal_to_ignoring_case(company_name));
        }

        string create_error_message_from(RegisterNewCompany dto)
        {
            return "A Company named {0}, has already been submitted!".formatted_using(dto.company_name);
        }
    }
}