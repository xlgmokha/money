using System;

namespace MoMoney.Domain.accounting.billing
{
    public interface ILedgerEntry
    {
        DateTime entry_date();
    }
}