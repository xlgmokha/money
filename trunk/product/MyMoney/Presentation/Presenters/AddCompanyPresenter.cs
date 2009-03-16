using System.Linq;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Presenters.billing.dto;
using MoMoney.Presentation.Views;
using MoMoney.Presentation.Views.core;
using MoMoney.Tasks.application;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Presenters
{
    public interface IAddCompanyPresenter : IContentPresenter
    {
        void submit(register_new_company dto);
    }

    public class AddCompanyPresenter : IAddCompanyPresenter
    {
        private readonly IAddCompanyView view;
        private readonly IBillingTasks tasks;

        public AddCompanyPresenter(IAddCompanyView view, IBillingTasks tasks)
        {
            this.view = view;
            this.tasks = tasks;
        }

        public void run()
        {
            view.attach_to(this);
            view.display(tasks.all_companys());
        }

        public void submit(register_new_company dto)
        {
            if (company_has_already_been_registered(dto))
            {
                view.notify(create_error_message_from(dto));
            }
            else
            {
                tasks.register_new_company(dto);
                view.display(tasks.all_companys());
            }
        }

        private bool company_has_already_been_registered(register_new_company dto)
        {
            return tasks.all_companys().Count(x => x.name.is_equal_to_ignoring_case(dto.company_name)) > 0;
        }

        private string create_error_message_from(register_new_company dto)
        {
            return "A Company named {0}, has already been submitted!".formatted_using(dto.company_name);
        }

        IDockedContentView IContentPresenter.View
        {
            get { return view; }
        }
    }
}