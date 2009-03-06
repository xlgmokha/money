using MoMoney.Domain.Core;

namespace MoMoney.Domain.accounting
{
    public interface IInvoice
    {
        void pay(IMoney two_thousand_dollars);
        IMoney total();
    }
}