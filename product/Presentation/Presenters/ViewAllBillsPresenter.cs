using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Views;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.Presentation.Presenters
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