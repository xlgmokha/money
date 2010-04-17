using System;
using presentation.windows.common;

namespace presentation.windows.presenters
{
    public class AddNewAccountPresenter : DialogPresenter
    {
        UICommandBuilder builder;

        public AddNewAccountPresenter(UICommandBuilder builder)
        {
            this.builder = builder;
        }

        public void present()
        {
            Accept = builder.build<CreateNewAccount>(this);
            Cancel = builder.build<CancelCommand>(this);
        }

        public string account_name { get; set; }
        public string currency { get; set; }
        public Action close { get; set; }
        public IObservableCommand Accept { get; set; }
        public IObservableCommand Cancel { get; set; }

        public class CreateNewAccount : UICommand<AddNewAccountPresenter>
        {
            ServiceBus bus;

            public CreateNewAccount(ServiceBus bus)
            {
                this.bus = bus;
            }

            protected override void run(AddNewAccountPresenter presenter)
            {
                bus.publish<common.messages.CreateNewAccount>(x =>
                {
                    x.account_name = presenter.account_name;
                    x.currency = presenter.currency;
                });
                presenter.close();
            }
        }
    }
}