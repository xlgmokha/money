using MyMoney.Domain.Core;

namespace MyMoney.Domain.accounting
{
    public interface IInvoice
    {
        void pay(IMoney two_thousand_dollars);
        IMoney total();
    }
}