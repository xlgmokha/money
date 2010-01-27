using System.Collections.Generic;
using MoMoney.DTO;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters;
using momoney.presentation.views;
using MoMoney.Service.Contracts.Application;

namespace momoney.presentation.presenters
{
    public class AddBillPaymentPresenter : TabPresenter<IAddBillPaymentView>
    {
        readonly ICommandPump pump;

        public AddBillPaymentPresenter(IAddBillPaymentView view, ICommandPump pump) : base(view)
        {
            this.pump = pump;
        }

        protected override void present()
        {
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