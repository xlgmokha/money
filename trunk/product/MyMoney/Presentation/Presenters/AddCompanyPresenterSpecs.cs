using developwithpassion.bdd.contexts;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views;
using MoMoney.Tasks.application;
using MoMoney.Tasks.infrastructure.core;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Presenters
{
    [Concern(typeof (AddCompanyPresenter))]
    public abstract class behaves_like_the_add_company_presenter :
        concerns_for<IAddCompanyPresenter, AddCompanyPresenter>
    {
        context c = () =>
                        {
                            view = the_dependency<IAddCompanyView>();
                            tasks = the_dependency<IBillingTasks>();
                            pump = the_dependency<ICommandPump>();
                        };

        protected static IAddCompanyView view;
        protected static IBillingTasks tasks;
        protected static ICommandPump pump;
    }

    public class when_the_user_is_about_to_add_an_expense : behaves_like_the_add_company_presenter
    {
        it should_display_the_correct_screen = () => view.was_told_to(x => x.attach_to(sut));

        because b = () => sut.run();
    }

    public class when_registering_a_new_company : behaves_like_the_add_company_presenter
    {
        context c = () => when_the(tasks).is_asked_for(x => x.all_companys()).it_will_return_nothing();

        because b = () =>
                        {
                            dto = new RegisterNewCompany {company_name = "Microsoft"};
                            sut.submit(dto);
                        };

        //it should_add_the_new_company = () => tasks.was_told_to(x => x.register_new_company(dto));
        it should_add_the_new_company =
            () => pump.was_told_to(x => x.run<IRegisterNewCompanyCommand, RegisterNewCompany>(dto));

        static RegisterNewCompany dto;
    }
}