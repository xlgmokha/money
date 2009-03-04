using System;
using System.Collections.Generic;
using jpboodhoo.bdd.contexts;
using MyMoney.Domain.accounting.billing;
using MyMoney.Domain.Core;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;
using mocking_extensions=MyMoney.Testing.spechelpers.core.mocking_extensions;

namespace MyMoney.Domain.accounting
{
    [Concern(typeof (general_ledger))]
    public abstract class behaves_like_a_general_ledger : concerns_for<IGeneralLedger, general_ledger>
    {
        public override IGeneralLedger create_sut()
        {
            return new general_ledger(new List<ILedgerEntry> {february_first, february_twenty_first, april_first});
        }

        context c = () =>
                        {
                            february_first = an<ILedgerEntry>();
                            february_twenty_first = an<ILedgerEntry>();
                            april_first = an<ILedgerEntry>();
                        };

        protected static ILedgerEntry february_first;
        protected static ILedgerEntry february_twenty_first;
        protected static ILedgerEntry april_first;
    }

    public class when_retrieving_all_the_entries_for_a_month_in_the_past : behaves_like_a_general_ledger
    {
        it should_return_all_the_entries_posted_for_that_month = () =>
                                                                     {
                                                                         result.should_contain(february_first);
                                                                         result.should_contain(february_twenty_first);
                                                                     };

        it should_not_return_any_entries_that_were_not_posted_for_that_month =
            () => assertions.should_not_contain(result, april_first);

        context c = () =>
                        {
                            february_first = an<ILedgerEntry>();
                            february_twenty_first = an<ILedgerEntry>();
                            april_first = an<ILedgerEntry>();

                            february_first.is_told_to(x => x.entry_date()).it_will_return(new DateTime(2008, 02, 01));
                            february_twenty_first.is_told_to(x => x.entry_date()).it_will_return(new DateTime(2008, 02, 21));
                            april_first.is_told_to(x => x.entry_date()).it_will_return(new DateTime(2008, 04, 01));
                        };

        because b = () => { result = sut.get_all_the_entries_for(Months.February); };

        static IEnumerable<ILedgerEntry> result;
    }
}