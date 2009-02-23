using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Presenters.billing.dto;
using MyMoney.Presentation.Views;
using MyMoney.Tasks.application;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;

namespace MyMoney.Presentation.Presenters
{
    [Concern(typeof (add_company_presenter))]
    public class behaves_like_the_add_company_presenter : concerns_for<IAddCompanyPresenter, add_company_presenter>
    {
        public override IAddCompanyPresenter create_sut()
        {
            return new add_company_presenter(view, tasks);
        }

        context c = () =>
                        {
                            view = an<IAddCompanyView>();
                            tasks = an<IBillingTasks>();
                        };

        protected static IAddCompanyView view;
        protected static IBillingTasks tasks;
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
                            dto = new register_new_company {company_name = "Microsoft"};
                            sut.submit(dto);
                        };

        it should_add_the_new_company = () => tasks.was_told_to(x => x.register_new_company(dto));

        static register_new_company dto;
    }
}