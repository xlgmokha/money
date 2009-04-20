using System.Collections.Generic;
using Gorilla.Commons.Infrastructure;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.billing;
using MoMoney.Tasks.application;

namespace MoMoney.Presentation.Presenters.billing
{
    public interface IAddBillPaymentPresenter : IContentPresenter
    {
        void submit_bill_payment(AddNewBillDTO dto);
    }

    public class AddBillPaymentPresenter : ContentPresenter<IAddBillPaymentView>, IAddBillPaymentPresenter
    {
        readonly ICommandPump pump;

        public AddBillPaymentPresenter(IAddBillPaymentView view, ICommandPump pump) : base(view)
        {
            this.pump = pump;
        }

        public override void run()
        {
            view.attach_to(this);
            pump
                .run<IEnumerable<ICompany>, IGetAllCompanysQuery>(view)
                .run<IEnumerable<BillInformationDTO>, IGetAllBillsQuery>(view);
        }

        public void submit_bill_payment(AddNewBillDTO dto)
        {
            pump
                .run<ISaveNewBillCommand, AddNewBillDTO>(dto)
                .run<IEnumerable<BillInformationDTO>, IGetAllBillsQuery>(view);
        }
    }
}