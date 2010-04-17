using presentation.windows.common;
using presentation.windows.common.messages;
using presentation.windows.server.domain.accounting;
using presentation.windows.server.orm;

namespace presentation.windows.server.handlers
{
    public class SaveNewAccountCommand : Handler<CreateNewAccount>
    {
        AccountRepository accounts;
        ServiceBus bus;

        public SaveNewAccountCommand(AccountRepository accounts, ServiceBus bus)
        {
            this.accounts = accounts;
            this.bus = bus;
        }

        public void handle(CreateNewAccount item)
        {
            accounts.save(Account.New(item.account_name, Currency.named(item.currency)));
            bus.publish<NewAccountCreated>(x => x.name = item.account_name);
        }
    }
}