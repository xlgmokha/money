using System;
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.Domain.accounting.billing;
using MoMoney.Domain.Accounting.Growth;
using MoMoney.Domain.Core;

namespace MoMoney.Domain.accounting
{
    [Concern(typeof (AccountHolder))]
    public abstract class behaves_like_an_account_holder : concerns_for<IAccountHolder, AccountHolder>
    {
        //public override IAccountHolder create_sut()
        //{
        //    return new AccountHolder();
        //}
    }

    public class when_a_customer_is_checking_for_any_bills_that_have_not_been_paid : behaves_like_an_account_holder
    {
        it should_return_all_the_unpaid_bills = () =>
                                                    {
                                                        result.should_contain(first_unpaid_bill);
                                                        result.should_contain(second_unpaid_bill);
                                                    };

        context c = () =>
                        {
                            first_unpaid_bill = an<IBill>();
                            second_unpaid_bill = an<IBill>();
                            paid_bill = an<IBill>();

                            first_unpaid_bill.is_told_to(x => x.is_paid_for()).it_will_return(false);
                            second_unpaid_bill.is_told_to(x => x.is_paid_for()).it_will_return(false);
                            paid_bill.is_told_to(x => x.is_paid_for()).it_will_return(true);
                        };

        because b = () =>
                        {
                            sut.receive(first_unpaid_bill);
                            sut.receive(paid_bill);
                            sut.receive(second_unpaid_bill);
                            result = sut.collect_all_the_unpaid_bills();
                        };

        static IEnumerable<IBill> result;
        static IBill first_unpaid_bill;
        static IBill second_unpaid_bill;
        static IBill paid_bill;
    }

    [Concern(typeof (AccountHolder))]
    public class when_an_account_holder_is_calculating_their_income_for_a_year : behaves_like_an_account_holder
    {
        context c = () =>
                        {
                            income_for_january_2007 = an<IIncome>();
                            income_for_february_2007 = an<IIncome>();
                            income_for_february_2008 = an<IIncome>();

                            income_for_january_2007.is_told_to(x => x.date_of_issue).it_will_return(
                                new DateTime(2007, 01, 01).as_a_date());
                            income_for_january_2007.is_told_to(x => x.amount_tendered).it_will_return(new Money(1000, 00));

                            income_for_february_2007.is_told_to(x => x.date_of_issue).it_will_return(
                                new DateTime(2007, 02, 01).as_a_date());
                            income_for_february_2007.is_told_to(x => x.amount_tendered).it_will_return(new Money(1000,
                                                                                                                 00));

                            income_for_february_2008.is_told_to(x => x.date_of_issue).it_will_return(
                                new DateTime(2008, 02, 01).as_a_date());
                            income_for_february_2008.is_told_to(x => x.amount_tendered).it_will_return(new Money(1000,
                                                                                                                 00));
                        };

        because b = () =>
                        {
                            sut.receive(income_for_january_2007);
                            sut.receive(income_for_february_2007);
                            sut.receive(income_for_february_2008);
                            result = sut.calculate_income_for(2007.as_a_year());
                        };

        it should_return_the_correct_amount = () => result.should_be_equal_to(2000.as_money());

        static IMoney result;
        static IIncome income_for_january_2007;
        static IIncome income_for_february_2007;
        static IIncome income_for_february_2008;
    }
}