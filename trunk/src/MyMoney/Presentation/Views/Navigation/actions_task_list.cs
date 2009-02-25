using System;
using System.IO;
using MyMoney.Presentation.Presenters;
using MyMoney.Presentation.Presenters.billing;
using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Presentation.Presenters.income;
using MyMoney.Presentation.Presenters.reporting;
using MyMoney.Presentation.Resources;
using MyMoney.Presentation.Views.core;
using MyMoney.Presentation.Views.Shell;
using WeifenLuo.WinFormsUI.Docking;

namespace MyMoney.Presentation.Views.Navigation
{
    public interface IActionsTaskView : IDockedContentView
    {
        void display();
    }

    public partial class actions_task_list : DockContent, IActionsTaskView
    {
        private readonly IShell shell;
        private readonly IRunPresenterCommand command;

        public actions_task_list(IShell shell, IRunPresenterCommand command)
        {
            InitializeComponent();
            CloseButton = false;
            CloseButtonVisible = false;
            this.shell = shell;
            this.command = command;

            initialize_the_ui();
        }

        private void initialize_the_ui()
        {
            TabText = "Action Items";
            Icon = ApplicationIcons.FileExplorer;
            ux_system_task_pane.UseClassicTheme();
            ux_system_task_pane.Expandos.Add
            //ux_system_task_pane.UseCustomTheme(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "itunes.dat"));
        }

        public void display()
        {
            ux_add_company.Text = "Add Company";
            ux_add_company.Image = ApplicationImages.ReadingABill;
            ux_add_company.Click += (sender, e) => command.execute<IAddCompanyPresenter>();

            ux_add_bill_payment.Text = "Add Bill Payments";
            ux_add_bill_payment.Image = ApplicationImages.ReadingABill;
            ux_add_bill_payment.Click += (sender, e) => command.execute<IAddBillPaymentPresenter>();

            ux_view_all_bill_payments.Text = "View All Bills";
            ux_view_all_bill_payments.Image = ApplicationImages.ReadingABill;
            ux_view_all_bill_payments.Click += (sender, e) => command.execute<IViewAllBillsPresenter>();

            ux_view_all_bill_payments_report.Text = "View All Bills";
            ux_view_all_bill_payments_report.Image = ApplicationImages.ReadingABill;
            ux_view_all_bill_payments_report.Click += (sender, e) => command.execute<IViewAllBillsReportPresenter>();

            ux_add_new_income.Text = "Add New Income";
            ux_add_new_income.Image = ApplicationImages.ReadingABill;
            ux_add_new_income.Click += (sender, e) => command.execute<IAddNewIncomePresenter>();

            ux_view_all_income.Text = "View All Income";
            ux_view_all_income.Image = ApplicationImages.ReadingABill;
            ux_view_all_income.Click += (sender, e) => command.execute<IViewIncomeHistoryPresenter>();

            shell.add(this);
            DockState = DockState.DockLeft;
        }
    }
}