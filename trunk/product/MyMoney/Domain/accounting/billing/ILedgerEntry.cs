using System;

namespace MyMoney.Domain.accounting.billing
{
    public interface ILedgerEntry
    {
        DateTime entry_date();
    }
}