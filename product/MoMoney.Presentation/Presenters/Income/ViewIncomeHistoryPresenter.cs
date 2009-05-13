using System.Collections.Generic;
using Gorilla.Commons.Infrastructure;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views.income;
using MoMoney.Service.Application;

namespace MoMoney.Presentation.Presenters.income
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