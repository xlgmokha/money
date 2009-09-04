using System.Collections.Generic;
using Gorilla.Commons.Infrastructure;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views.income;
using MoMoney.Service.Application;

namespace MoMoney.Presentation.Presenters.income
{
    public interface IAddNewIncomePresenter : IContentPresenter
    {
        void submit_new(IncomeSubmissionDto income);
    }

    public class AddNewIncomePresenter : ContentPresenter<IAddNewIncomeView>, IAddNewIncomePresenter
    {
        readonly ICommandPump pump;

        public AddNewIncomePresenter(IAddNewIncomeView view, ICommandPump pump) : base(view)
        {
            this.pump = pump;
        }

        public override void run()
        {
            view.attach_to(this);
            pump.run<IEnumerable<CompanyDTO>, IGetAllCompanysQuery>(view);
            pump.run<IEnumerable<IncomeInformationDTO>, IGetAllIncomeQuery>(view);
        }

        public void submit_new(IncomeSubmissionDto income)
        {
            pump.run<IAddNewIncomeCommand, IncomeSubmissionDto>(income);
            pump.run<IEnumerable<IncomeInformationDTO>, IGetAllIncomeQuery>(view);
        }
    }
}