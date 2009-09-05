using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Views.income;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Presentation.Presenters.income
{
    public interface IAddNewIncomePresenter : IContentPresenter
    {
        void submit_new(IncomeSubmissionDTO income);
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

        public void submit_new(IncomeSubmissionDTO income)
        {
            pump.run<IAddNewIncomeCommand, IncomeSubmissionDTO>(income);
            pump.run<IEnumerable<IncomeInformationDTO>, IGetAllIncomeQuery>(view);
        }
    }
}