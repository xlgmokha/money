using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Presentation.Presenters
{
    public class AddNewIncomePresenter : ContentPresenter<IAddNewIncomeView>
    {
        readonly ICommandPump pump;

        public AddNewIncomePresenter(IAddNewIncomeView view, ICommandPump pump) : base(view)
        {
            this.pump = pump;
        }

        public override void present()
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