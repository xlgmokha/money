using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Views;
using MoMoney.Service.Contracts.Application;

namespace momoney.presentation.presenters
{
    public class ViewAllBillsPresenter : ContentPresenter<IViewAllBills>
    {
        readonly ICommandPump pump;

        public ViewAllBillsPresenter(IViewAllBills view, ICommandPump pump) : base(view)
        {
            this.pump = pump;
        }

        public override void present()
        {
            view.attach_to(this);
            pump.run<IEnumerable<BillInformationDTO>, IGetAllBillsQuery>(view);
        }
    }
}