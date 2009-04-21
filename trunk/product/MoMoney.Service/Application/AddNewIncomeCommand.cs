using System.Linq;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.Domain.Core;
using MoMoney.Presentation.Model.interaction;
using MoMoney.Presentation.Presenters.income.dto;
using MoMoney.Tasks.application;

namespace MoMoney.Service.Application
{
    public interface IAddNewIncomeCommand : IParameterizedCommand<IncomeSubmissionDto>
    {
    }

    public class AddNewIncomeCommand : IAddNewIncomeCommand
    {
        readonly IIncomeTasks tasks;
        readonly INotification notification;

        public AddNewIncomeCommand(IIncomeTasks tasks, INotification notification)
        {
            this.tasks = tasks;
            this.notification = notification;
        }

        public void run(IncomeSubmissionDto item)
        {
            if (similar_income_has_been_submitted(item))
            {
                notification.notify("You have already submitted this income");
            }
            tasks.add_new(item);
        }

        bool similar_income_has_been_submitted(IncomeSubmissionDto income)
        {
            if (tasks.retrive_all_income().Count() == 0) return false;
            return tasks
                       .retrive_all_income()
                       .where(x => x.amount_tendered.Equals(income.amount.as_money()))
                       .where(x => x.company.id.Equals(income.company_id))
                       .where(x => x.date_of_issue.Equals(income.recieved_date.as_a_date()))
                       .Count() > 0;
        }
    }
}