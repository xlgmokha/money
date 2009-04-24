using MoMoney.Domain.Core;

namespace MoMoney.Domain.accounting
{
    public interface IInvoice
    {
        void pay(Money two_thousand_dollars);
        Money total();
    }
}