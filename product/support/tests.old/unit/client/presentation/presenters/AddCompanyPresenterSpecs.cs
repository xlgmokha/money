using MoMoney.DTO;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Views;
using MoMoney.Service.Contracts.Application;

namespace tests.unit.client.presentation.presenters
{
    [Concern(typeof (AddCompanyPresenter))]
    public abstract class behaves_like_the_add_company_presenter : tests_for<AddCompanyPresenter>
    {
        context c = () =>
        {
            view = dependency<IAddCompanyView>();
            pump = dependency<ICommandPump>();
        };

        static protected IAddCompanyView view;
        static protected ICommandPump pump;
    }

    [Concern(typeof (AddCompanyPresenter))]
    public class when_registering_a_new_company : behaves_like_the_add_company_presenter
    {
        context c = () =>
        {
            dto = new RegisterNewCompany {company_name = "Microsoft"};
            pump
                .is_told_to(x => x.run<IRegisterNewCompanyCommand, RegisterNewCompany>(dto))
                .it_will_return(pump);
        };

        because b = () => sut.submit(dto);

        it should_add_the_new_company =
            () => pump.was_told_to(x => x.run<IRegisterNewCompanyCommand, RegisterNewCompany>(dto));

        static RegisterNewCompany dto;
    }
}