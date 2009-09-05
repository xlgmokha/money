using System;

namespace MoMoney.Domain.Accounting
{
    public interface ILedgerEntry
    {
        DateTime entry_date();
    }
}