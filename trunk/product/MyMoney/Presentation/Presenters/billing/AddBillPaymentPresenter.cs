using System.Collections.Generic;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.billing;
using MoMoney.Tasks.application;
using MoMoney.Tasks.infrastructure.core;

namespace MoMoney.Presentation.Presenters.billing
{
    public interface IAddBillPaymentPresenter : IContentPresenter
    {
        void submit_bill_payment(AddNewBillDTO dto);
    }

    public class AddBillPaymentPresenter : ContentPresenter<IAddBillPaymentView>, IAddBillPaymentPresenter
    {
        readonly IBillingTasks tasks;
        readonly ICommandPump pump;

        public AddBillPaymentPresenter(IAddBillPaymentView view, ICommandPump pump, IBillingTasks tasks) : base(view)
        {
            this.pump = pump;
            this.tasks = tasks;
        }

        public override void run()
        {
            view.attach_to(this);
            pump.run<IEnumerable<ICompany>, IGetAllCompanysQuery>(view);
            pump.run<IEnumerable<bill_information_dto>, IGetAllBillsQuery>(view);
            //view.run(tasks.all_companys());
            //view.run(tasks.all_bills().map_all_using(x => map_from(x)));
        }

        public void submit_bill_payment(AddNewBillDTO dto)
        {
            tasks.save_a_new_bill_using(dto);
            //view.run(tasks.all_bills().map_all_using(x => map_from(x)));
            pump.run<IEnumerable<bill_information_dto>, IGetAllBillsQuery>(view);
        }

        //bill_information_dto map_from(IBill bill)
        //{
        //    return new bill_information_dto
        //               {
        //                   company_name = bill.company_to_pay.name,
        //                   the_amount_owed = bill.the_amount_owed.ToString(),
        //                   due_date = bill.due_date.to_date_time(),
        //               };
        //}
    }
}