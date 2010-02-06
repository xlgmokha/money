using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Presenters;
using momoney.presentation.views;
using MoMoney.Presentation.Views;
using MoMoney.Service.Contracts.Application;

namespace tests.unit.client.presentation.presenters
{
    [Concern(typeof (AddNewIncomePresenter))]
    public abstract class behaves_like_add_new_income_presenter : tests_for<AddNewIncomePresenter>
    {
        context c = () =>
        {
            view = dependency<IAddNewIncomeView>();
            pump = dependency<ICommandPump>();
        };

        static protected ICommandPump pump;
        static protected IAddNewIncomeView view;
    }

    [Concern(typeof (AddNewIncomePresenter))]
    public class when_new_income_is_submitted : behaves_like_add_new_income_presenter
    {
        it should_add_the_income_to_the_account_holders_account =
            () => pump.was_told_to(x => x.run<IAddNewIncomeCommand, IncomeSubmissionDTO>(income));

        it should_display_the_new_income =
            () => pump.was_told_to(x => x.run<IEnumerable<IncomeInformationDTO>, IGetAllIncomeQuery>(view));

        context c = () =>
        {
            income = new IncomeSubmissionDTO {};
        };

        because b = () => sut.submit_new(income);

        static IncomeSubmissionDTO income;
    }

    [Concern(typeof (AddNewIncomePresenter))]
    public class when_loaded : behaves_like_add_new_income_presenter
    {
        it should_display_a_list_of_all_the_registered_company_to_select =
            () => pump.was_told_to(x => x.run<IEnumerable<CompanyDTO>, IGetAllCompanysQuery>(view));

        it should_display_the_income_already_added =
            () => pump.was_told_to(x => x.run<IEnumerable<IncomeInformationDTO>, IGetAllIncomeQuery>(view));

        context c = () =>
        {
            shell = an<Shell>();
        };

        because b = () => sut.present(shell);
        static Shell shell;
    }
}