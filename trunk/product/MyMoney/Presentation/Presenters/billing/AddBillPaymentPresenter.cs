using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views.billing;
using MoMoney.Tasks.application;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters.billing
{
    public interface IAddBillPaymentPresenter : IContentPresenter
    {
        void submit_bill_payment(add_new_bill_dto dto);
    }

    public class AddBillPaymentPresenter : ContentPresenter<IAddBillPaymentView>, IAddBillPaymentPresenter
    {
        readonly IBillingTasks tasks;

        public AddBillPaymentPresenter(IAddBillPaymentView view, IBillingTasks tasks) : base(view)
        {
            this.tasks = tasks;
        }

        public override void run()
        {
            view.attach_to(this);
            view.display(tasks.all_companys());
            view.display(tasks.all_bills().map_all_using(x => map_from(x)));
        }

        public void submit_bill_payment(add_new_bill_dto dto)
        {
            tasks.save_a_new_bill_using(dto);
            view.display(tasks.all_bills().map_all_using(x => map_from(x)));
        }

        bill_information_dto map_from(IBill bill)
        {
            return new bill_information_dto
                       {
                           company_name = bill.company_to_pay.name,
                           the_amount_owed = bill.the_amount_owed.ToString(),
                           due_date = bill.due_date.to_date_time(),
                       };
        }
    }
}