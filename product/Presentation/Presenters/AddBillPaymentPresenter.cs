using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters;
using momoney.presentation.views;
using MoMoney.Service.Contracts.Application;

namespace momoney.presentation.presenters
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
                .run<IEnumerable<CompanyDTO>, IGetAllCompanysQuery>(view)
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