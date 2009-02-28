using System.Collections.Generic;
using jpboodhoo.bdd.contexts;
using MyMoney.Domain.accounting.billing;
using MyMoney.Testing.spechelpers.contexts;
using assertion_extensions=MyMoney.Testing.spechelpers.core.assertion_extensions;

namespace MyMoney.DataAccess.repositories
{
    public class when_loading_all_the_bills_from_the_repository : behaves_like_a_repository
    {
        it should_return_all_the_bills_in_the_database = () => assertion_extensions.should_contain(results, first_bill);

        context c = () => { first_bill = an<IBill>(); };

        because b = () =>
                        {
                            sut.save(first_bill);
                            results = sut.all<IBill>();
                        };

        static IEnumerable<IBill> results;
        static IBill first_bill;
    }
}