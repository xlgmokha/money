using System;
using System.Collections.Generic;
using MyMoney.Domain.accounting.billing;
using MyMoney.Domain.Core;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;

namespace MyMoney.Domain.accounting
{
    public class GeneralLedgerSpecs
    {
    }

    [Concern(typeof (general_ledger))]
    public class when_retrieving_all_the_entries_for_a_month_in_the_past : old_context_specification<IGeneralLedger>
    {
        [Observation]
        public void it_should_return_all_the_entries_posted_for_that_month()
        {
            result.should_contain(february_first);
            result.should_contain(february_twenty_first);
        }

        [Observation]
        public void it_should_not_return_any_entries_that_were_not_posted_for_that_month()
        {
            result.should_not_contain(april_first);
        }

        protected override IGeneralLedger context()
        {
            february_first = an<ILedgerEntry>();
            february_twenty_first = an<ILedgerEntry>();
            april_first = an<ILedgerEntry>();

            february_first.is_told_to(x => x.entry_date()).Return(new DateTime(2008, 02, 01));
            february_twenty_first.is_told_to(x => x.entry_date()).Return(new DateTime(2008, 02, 21));
            april_first.is_told_to(x => x.entry_date()).Return(new DateTime(2008, 04, 01));

            return new general_ledger(new List<ILedgerEntry> {february_first, february_twenty_first, april_first});
        }

        protected override void because()
        {
            result = sut.get_all_the_entries_for(Months.February);
        }

        private IEnumerable<ILedgerEntry> result;
        private ILedgerEntry february_first;
        private ILedgerEntry february_twenty_first;
        private ILedgerEntry april_first;
    }
}