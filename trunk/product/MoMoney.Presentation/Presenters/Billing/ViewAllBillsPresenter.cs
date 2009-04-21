using System.Collections.Generic;
using Gorilla.Commons.Infrastructure;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.billing;
using MoMoney.Tasks.application;

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