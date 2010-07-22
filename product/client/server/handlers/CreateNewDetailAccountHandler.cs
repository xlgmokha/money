using presentation.windows.common;
using presentation.windows.common.messages;
using presentation.windows.server.domain.accounting;
using presentation.windows.server.orm;

namespace presentation.windows.server.handlers
{
    public class CreateNewDetailAccountHandler : AbstractHandler<CreateNewDetailAccountCommand>
    {
        AccountRepository accounts;
        ServiceBus bus;

        public CreateNewDetailAccountHandler(AccountRepository accounts, ServiceBus bus)
        {
            this.accounts = accounts;
            this.bus = bus;
        }

        public override void handle(CreateNewDetailAccountCommand item)
        {
            accounts.save(DetailAccount.New(Currency.named(item.currency)));
            bus.publish<NewAccountCreated>(x => x.name = item.account_name);
        }
    }
}