using System.Collections.Generic;
using System.Linq;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views;
using MoMoney.Tasks.application;
using MoMoney.Tasks.infrastructure.core;

namespace MoMoney.Presentation.Presenters
{
    public interface IAddCompanyPresenter : IContentPresenter
    {
        void submit(RegisterNewCompany dto);
    }

    public class AddCompanyPresenter : ContentPresenter<IAddCompanyView>, IAddCompanyPresenter
    {
        readonly IBillingTasks tasks;
        readonly ICommandPump pump;

        public AddCompanyPresenter(IAddCompanyView view, IBillingTasks tasks, ICommandPump pump) : base(view)
        {
            this.pump = pump;
            this.tasks = tasks;
        }

        public override void run()
        {
            view.attach_to(this);
            pump.run<IEnumerable<ICompany>, IGetAllCompanysQuery>(view);
        }

        public void submit(RegisterNewCompany dto)
        {
            if (company_has_already_been_registered(dto))
                view.notify(create_error_message_from(dto));
            else
                pump
                    .run<IRegisterNewCompanyCommand, RegisterNewCompany>(dto)
                    .run<IEnumerable<ICompany>, IGetAllCompanysQuery>(view);
        }

        bool company_has_already_been_registered(RegisterNewCompany dto)
        {
            return tasks.all_companys().Count(x => x.name.is_equal_to_ignoring_case(dto.company_name)) > 0;
        }

        string create_error_message_from(RegisterNewCompany dto)
        {
            return "A Company named {0}, has already been submitted!".formatted_using(dto.company_name);
        }
    }
}