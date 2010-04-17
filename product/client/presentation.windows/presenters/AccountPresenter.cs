using presentation.windows.views;

namespace presentation.windows.presenters
{
    public class AccountPresenter : TabPresenter
    {
        UICommandBuilder ui_builder;

        public AccountPresenter(UICommandBuilder ui_builder)
        {
            this.ui_builder = ui_builder;
        }

        public void present()
        {
            AddAccount = ui_builder.build<AddNewAccountCommand>(this);
        }

        public string Header
        {
            get { return "Accounts"; }
        }

        IObservableCommand AddAccount { get; set; }

        public class AddNewAccountCommand : UICommand<AccountPresenter>
        {
            ApplicationController controller;

            public AddNewAccountCommand(ApplicationController controller)
            {
                this.controller = controller;
            }

            protected override void run(AccountPresenter presenter)
            {
                controller.launch_dialog<AddNewAccountPresenter, AddNewAccountDialog>();
            }
        }
    }
}