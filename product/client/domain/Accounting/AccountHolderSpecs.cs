using System;
using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using Gorilla.Commons.Utility;
using MoMoney.Domain.Accounting;
using MoMoney.Domain.Core;
using Rhino.Mocks;

namespace MoMoney.Domain.accounting
{
    public class AccountHolderSpecs
    {
        [Concern(typeof (AccountHolder))]
        public abstract class concern : concerns_for<AccountHolder>
        {
        }

        public class when_a_customer_is_checking_for_any_bills_that_have_not_been_paid : concern
        {
            it should_return_all_the_unpaid_bills = () =>
                                                    {
                                                        result.should_contain(first_unpaid_bill);
                                                        result.should_contain(second_unpaid_bill);
                                                    };

            context c = () =>
                        {
                            first_unpaid_bill = an<Bill>();
                            second_unpaid_bill = an<Bill>();
                            paid_bill = an<Bill>();

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

            static IEnumerable<Bill> result;
            static Bill first_unpaid_bill;
            static Bill second_unpaid_bill;
            static Bill paid_bill;
        }

        [Concern(typeof (AccountHolder))]
        public class when_an_account_holder_is_calculating_their_income_for_a_year : concern
        {
            context c = () =>
                        {
                            income_for_january_2007 = MockRepository.GenerateMock<Income>();
                            income_for_february_2007 = MockRepository.GenerateMock<Income>();
                            income_for_february_2008 = MockRepository.GenerateMock<Income>();

                            income_for_january_2007.is_told_to(x => x.date_of_issue).it_will_return<Date>(new DateTime(2007, 01, 01));
                            income_for_january_2007.is_told_to(x => x.amount_tendered).it_will_return(new Money(1000, 00));

                            income_for_february_2007.is_told_to(x => x.date_of_issue).it_will_return<Date>(new DateTime(2007, 02, 01));
                            income_for_february_2007.is_told_to(x => x.amount_tendered).it_will_return(new Money(1000, 00));

                            income_for_february_2008.is_told_to(x => x.date_of_issue).it_will_return<Date>(new DateTime(2008, 02, 01));
                            income_for_february_2008.is_told_to(x => x.amount_tendered).it_will_return(new Money(1000, 00));
                        };

            because b = () =>
                        {
                            sut.receive(income_for_january_2007);
                            sut.receive(income_for_february_2007);
                            sut.receive(income_for_february_2008);
                            result = sut.calculate_income_for(2007);
                        };

            it should_return_the_correct_amount = () => result.should_be_equal_to(2000.as_money());

            static Money result;
            static Income income_for_january_2007;
            static Income income_for_february_2007;
            static Income income_for_february_2008;
        }
    }
}