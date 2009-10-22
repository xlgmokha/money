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

        public RegisterNewCompanyCommand(ICompanyFactory factory, Notification notification,
                                         ICompanyRepository companies)
        {
            this.factory = factory;
            this.notification = notification;
            this.companies = companies;
        }

        public void run(RegisterNewCompany item)
        {
            if (company_has_already_been_registered(item))
                notification.notify(create_error_message_from(item));
            else
                factory.create().change_name_to(item.company_name);
        }

        bool company_has_already_been_registered(RegisterNewCompany dto)
        {
            return companies.all().Count(x => x.name.is_equal_to_ignoring_case(dto.company_name)) > 0;
        }

        string create_error_message_from(RegisterNewCompany dto)
        {
            return "A Company named {0}, has already been submitted!".formatted_using(dto.company_name);
        }
    }
}