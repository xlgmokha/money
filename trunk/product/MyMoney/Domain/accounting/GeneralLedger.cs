using System;
using System.Collections.Generic;
using MyMoney.Domain.accounting.billing;
using MyMoney.Domain.Core;
using MyMoney.Utility.Extensions;

namespace MyMoney.Domain.accounting
{
    public interface IGeneralLedger
    {
        IEnumerable<ILedgerEntry> get_all_the_entries_for(IMonth month);
    }

    [Serializable]
    public class GeneralLedger : IGeneralLedger
    {
        private readonly List<ILedgerEntry> entries;

        public GeneralLedger(List<ILedgerEntry> entries)
        {
            this.entries = entries;
        }

        public IEnumerable<ILedgerEntry> get_all_the_entries_for(IMonth month)
        {
            return entries.where(x => month.represents(x.entry_date()));
        }
    }
}