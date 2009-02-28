using System;
using System.Collections.Generic;
using jpboodhoo.bdd.contexts;
using MyMoney.Domain.accounting.billing;
using MyMoney.Domain.Core;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.DataAccess.repositories
{
    public class when_loading_all_the_bills_from_the_repository : behaves_like_a_repository
    {
        public it should_return_all_the_bills_in_the_database = () => results.should_contain(first_bill);

        context c = () => { first_bill = new Bill(new Company("mokhan.ca"), new Money(1, 00), DateTime.Now); };

        because b = () =>
                        {
                            sut.save(first_bill);
                            results = sut.all<IBill>();
                        };

        static IEnumerable<IBill> results;
        static IBill first_bill;
    }
}