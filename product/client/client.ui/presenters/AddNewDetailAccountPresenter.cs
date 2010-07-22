using System;
using System.Collections.Generic;
using presentation.windows.common;

namespace presentation.windows.presenters
{
    public class AddNewDetailAccountPresenter : DialogPresenter
    {
        UICommandBuilder builder;

        public AddNewDetailAccountPresenter(UICommandBuilder builder)
        {
            this.builder = builder;
        }

        public void present()
        {
            add = builder.build<CreateNewAccount>(this);
            cancel = builder.build<CancelCommand>(this);
            currencies = new[] { "CAD" }.to_observable();
        }

        public string account_name { get; set; }
        public string currency { get; set; }
        public IEnumerable<string> currencies { get; set; }
        public Action close { get; set; }
        public IObservableCommand add { get; set; }
        public IObservableCommand cancel { get; set; }

        public class CreateNewAccount : UICommand<AddNewDetailAccountPresenter>
        {
            ServiceBus bus;

            public CreateNewAccount(ServiceBus bus)
            {
                this.bus = bus;
            }

            protected override void run(AddNewDetailAccountPresenter presenter)
            {
                bus.publish<common.messages.CreateNewDetailAccountCommand>(x =>
                {
                    x.account_name = presenter.account_name;
                    x.currency = presenter.currency;
                });
                presenter.close();
            }
        }
    }
}