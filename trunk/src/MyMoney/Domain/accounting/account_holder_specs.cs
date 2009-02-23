using System;
using System.Collections.Generic;
using MyMoney.Domain.accounting.billing;
using MyMoney.Domain.accounting.financial_growth;
using MyMoney.Domain.Core;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;

namespace MyMoney.Domain.accounting
{
    public class account_holder_specs
    {}

    [Concern(typeof (account_holder))]
    public class when_a_customer_is_checking_for_any_bills_that_have_not_been_paid : old_context_specification<IAccountHolder>
    {
        [Observation]
        public void it_should_return_all_the_unpaid_bills()
        {
            result.should_contain(first_unpaid_bill);
            result.should_contain(second_unpaid_bill);
        }

        protected override IAccountHolder context()
        {
            first_unpaid_bill = an<IBill>();
            second_unpaid_bill = an<IBill>();
            paid_bill = an<IBill>();


            first_unpaid_bill.is_told_to(x => x.is_paid_for()).Return(false);
            second_unpaid_bill.is_told_to(x => x.is_paid_for()).Return(false);
            paid_bill.is_told_to(x => x.is_paid_for()).Return(true);

            var customer = new account_holder();
            customer.recieve(first_unpaid_bill);
            customer.recieve(paid_bill);
            customer.recieve(second_unpaid_bill);
            return customer;
        }

        protected override void because()
        {
            result = sut.collect_all_the_unpaid_bills();
        }

        private IEnumerable<IBill> result;
        private IBill first_unpaid_bill;
        private IBill second_unpaid_bill;
        private IBill paid_bill;
    }

    [Concern(typeof (account_holder))]
    public class when_an_account_holder_is_calculating_their_income_for_a_year : old_context_specification<IAccountHolder>
    {
        protected override IAccountHolder context()
        {
            var income_for_january_2007 = an<IIncome>();
            var income_for_february_2007 = an<IIncome>();
            var income_for_february_2008 = an<IIncome>();

            income_for_january_2007
                .is_told_to(x => x.date_of_issue)
                .Return(new DateTime(2007, 01, 01).as_a_date());
            income_for_january_2007
                .is_told_to(x => x.amount_tendered)
                .Return(new money(1000, 00));

            income_for_february_2007
                .is_told_to(x => x.date_of_issue)
                .Return(new DateTime(2007, 02, 01).as_a_date());
            income_for_february_2007
                .is_told_to(x => x.amount_tendered)
                .Return(new money(1000, 00));

            income_for_february_2008
                .is_told_to(x => x.date_of_issue)
                .Return(new DateTime(2008, 02, 01).as_a_date());
            income_for_february_2008
                .is_told_to(x => x.amount_tendered)
                .Return(new money(1000, 00));

            var system_under_test = new account_holder();
            system_under_test.recieve(income_for_january_2007);
            system_under_test.recieve(income_for_february_2007);
            system_under_test.recieve(income_for_february_2008);
            return system_under_test;
        }

        protected override void because()
        {
            result = sut.calculate_income_for(2007.as_a_year());
        }

        [Observation]
        public void it_should_return_the_correct_amount()
        {
            result.should_be_equal_to(2000.as_money());
        }

        private IMoney result;
    }
}