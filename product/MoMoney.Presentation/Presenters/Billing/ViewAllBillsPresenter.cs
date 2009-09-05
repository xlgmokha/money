using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views.billing;
using MoMoney.Service.Contracts.Application;
using ICommandPump=MoMoney.Presentation.Presenters.Commands.ICommandPump;

namespace MoMoney.Presentation.Presenters.billing
{
    public interface IViewAllBillsPresenter : IContentPresenter
    {
    }

    public class ViewAllBillsPresenter : ContentPresenter<IViewAllBills>, IViewAllBillsPresenter
    {
        readonly ICommandPump pump;

        public ViewAllBillsPresenter(IViewAllBills view, ICommandPump pump) : base(view)
        {
            this.pump = pump;
        }

        public override void run()
        {
            view.attach_to(this);
            pump.run<IEnumerable<BillInformationDTO>, IGetAllBillsQuery>(view);
        }
    }
}