using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Presentation.Presenters
{
    public class ViewIncomeHistoryPresenter : TabPresenter<IViewIncomeHistory>
    {
        readonly ICommandPump pump;

        public ViewIncomeHistoryPresenter(IViewIncomeHistory view, ICommandPump pump) : base(view)
        {
            this.pump = pump;
        }

        protected override void present()
        {
            pump.run<IEnumerable<IncomeInformationDTO>, IGetAllIncomeQuery>(view);
        }
    }
}