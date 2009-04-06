using System.Collections.Generic;
using System.Linq;
using MoMoney.Domain.accounting.billing;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Views.core;
using MoMoney.Tasks.application;
using MoMoney.Tasks.infrastructure.core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters
{
    public interface IAddCompanyPresenter : IContentPresenter
    {
        void submit(RegisterNewCompany dto);
    }

    public class AddCompanyPresenter : IAddCompanyPresenter
    {
        readonly IAddCompanyView view;
        readonly IBillingTasks tasks;
        readonly ICommandPump pump;

        public AddCompanyPresenter(IAddCompanyView view, IBillingTasks tasks, ICommandPump pump)
        {
            this.view = view;
            this.pump = pump;
            this.tasks = tasks;
        }

        public void run()
        {
            view.attach_to(this);
            view.run(tasks.all_companys());
            //pump.run<IEnumerable<ICompany>, IGetAllCompanysQuery>(view);
        }

        public void submit(RegisterNewCompany dto)
        {
            if (company_has_already_been_registered(dto))
            {
                view.notify(create_error_message_from(dto));
            }
            else
            {
                pump.run<IRegisterNewCompanyCommand, RegisterNewCompany>(dto);
                //pump.run<IEnumerable<ICompany>, IGetAllCompanysQuery>(view);
                view.run(tasks.all_companys());
            }
        }

        bool company_has_already_been_registered(RegisterNewCompany dto)
        {
            return tasks.all_companys().Count(x => x.name.is_equal_to_ignoring_case(dto.company_name)) > 0;
        }

        string create_error_message_from(RegisterNewCompany dto)
        {
            return "A Company named {0}, has already been submitted!".formatted_using(dto.company_name);
        }

        IDockedContentView IContentPresenter.View
        {
            get { return view; }
        }
    }
}