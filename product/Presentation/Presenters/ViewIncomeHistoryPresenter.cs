using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Presentation.Presenters
{
    public interface IViewIncomeHistoryPresenter : IContentPresenter
    {
    }

    public class ViewIncomeHistoryPresenter : ContentPresenter<IViewIncomeHistory>, IViewIncomeHistoryPresenter
    {
        readonly ICommandPump pump;

        public ViewIncomeHistoryPresenter(IViewIncomeHistory view, ICommandPump pump) : base(view)
        {
            this.pump = pump;
        }

        public override void run()
        {
            view.attach_to(this);
            pump.run<IEnumerable<IncomeInformationDTO>, IGetAllIncomeQuery>(view);
        }
    }
}